using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] public int towerLimit = 5;
    [SerializeField] public Tower towerPrefab;
    [SerializeField] Transform towerGroup;

    PlayerMoney playerMoney;
    MoneyTracker moneyTracker;
    TowerCounter towerCounter;
    public TowerInfo towerInfo;

    public int towerPrice;

    UpgradeTowers upgradeTowers;


    EnemySpawner enemySpawner;

    public WorldBlock baseWorldBlock;

    Queue<Tower> towerQueue = new Queue<Tower>();

    int currentTowers = 0;

    public void AddTower(WorldBlock baseWorldBlock)
    {
        towerPrice = towerPrefab.GetComponent<TowerInfo>().towerPrice;

        if (playerMoney.playerMoney >= towerPrice)
        {
            currentTowers = towerQueue.Count;

            if (currentTowers < towerLimit)
            {
                
                upgradeTowers.towerToUpgrade = InstantiateNewTower(baseWorldBlock);
                

                playerMoney.playerMoney -= towerPrice;
                moneyTracker.UpdateMoney(playerMoney.playerMoney);
                

            }
            else
            {   
                MoveExistingTower(baseWorldBlock);

            }
        } else
        {
            try
            {
                MoveExistingTower(baseWorldBlock);
            } catch
            {

            }
            
        }
        
        

    }

    private void MoveExistingTower(WorldBlock newBaseWorldBlock)
    {
        print("Too many towers dickwad");
        var oldTower = towerQueue.Dequeue();
        oldTower.baseWorldBlock.isPlaceable = true;
        newBaseWorldBlock.isPlaceable = false;
        oldTower.baseWorldBlock = newBaseWorldBlock;
        oldTower.transform.position = newBaseWorldBlock.transform.position;
        oldTower.GetComponent<AudioSource>().Play();
        towerQueue.Enqueue(oldTower);

        
        
        
       
    }

    private WeaponData InstantiateNewTower(WorldBlock baseWorldBlock)
    {
        var newTower = Instantiate(towerPrefab, baseWorldBlock.transform.position , Quaternion.identity, towerGroup);
        newTower.baseWorldBlock = baseWorldBlock;
        baseWorldBlock.isPlaceable = false;
        currentTowers++;
        towerQueue.Enqueue(newTower);
        towerCounter.updateCount();
        return newTower.GetComponentInChildren<WeaponData>();
    }

    void Start()
    {
        enemySpawner = gameObject.GetComponent<EnemySpawner>();
        playerMoney = FindObjectOfType<PlayerMoney>();
        moneyTracker = FindObjectOfType<MoneyTracker>();
        upgradeTowers = FindObjectOfType<UpgradeTowers>();
        towerCounter = FindObjectOfType<TowerCounter>();
        towerInfo = towerPrefab.GetComponent<TowerInfo>();
        towerPrice = towerInfo.towerPrice;
    }

    
    void Update()
    {
        
    }
}
