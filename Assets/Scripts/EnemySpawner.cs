using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy and Enemy Group")]
    [SerializeField] GameObject easyEnemy;
    [SerializeField] GameObject mediumEnemy;
    [SerializeField] GameObject hardEnemy;
    [SerializeField] GameObject reallyHardEnemy;
    [SerializeField] Transform enemies;

    [Header("Spawn Settings")]
    [SerializeField] float spawnDelay = 3f;
    [SerializeField] public int heightAdjust = 10;

    PlayerMoney playerMoney;
    AudioSource spawnSound;
    System.Random rnd;

    public bool levelComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        rnd = new System.Random();
        spawnSound = GetComponent<AudioSource>();
        playerMoney = FindObjectOfType<PlayerMoney>();

        StartCoroutine(SpawnEnemies(1,spawnDelay));

       



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SpawnEnemies(int level, float spawnWait)
    {
        levelComplete = false;

        int difficulty = 2;
        for (int i = 0; i < 100 * level; i++)
        {
            if (i % 10 == 0)
            {
                difficulty = i;
            }

            

            int enemyType = rnd.Next(0, 100 * level);

            if (enemyType <= (100 * level) - difficulty / 2 * level)
            {
                if (level < 3)
                {
                    Instantiate(easyEnemy, FindObjectOfType<PathFinder>().getPath()[0] + new Vector3Int(0, heightAdjust, 0),Quaternion.Euler(0f,40f,0f) ,enemies);
                } else
                {
                    Instantiate(mediumEnemy, FindObjectOfType<PathFinder>().getPath()[0] + new Vector3Int(0, heightAdjust, 0), Quaternion.Euler(0f,40f,0f), enemies);
                }
               

            } else if (enemyType <= (100 * level) - difficulty/5 && enemyType > (100 * level) - difficulty / 2 * level)
            {
                if (level < 3)
                {
                    Instantiate(hardEnemy, FindObjectOfType<PathFinder>().getPath()[0] + new Vector3Int(0, heightAdjust, 0), Quaternion.Euler(0f,40f,0f), enemies);
                }
                else
                {
                    Instantiate(reallyHardEnemy, FindObjectOfType<PathFinder>().getPath()[0] + new Vector3Int(0, heightAdjust, 0), Quaternion.Euler(0f,40f,0f), enemies);
                }
            }
            else
            {
                if (level < 3)
                {
                    Instantiate(mediumEnemy, FindObjectOfType<PathFinder>().getPath()[0] + new Vector3Int(0, heightAdjust, 0), Quaternion.Euler(0f,40f,0f), enemies);
                }
                else
                {
                    Instantiate(hardEnemy, FindObjectOfType<PathFinder>().getPath()[0] + new Vector3Int(0, heightAdjust, 0), Quaternion.Euler(0f,40f,0f), enemies);
                }
            }
            
            spawnSound.Play();
            if (spawnWait >= .1f * (10 - level))
            {
                spawnWait = spawnWait - 0.03f;
            }

            if (i == (100 * level) - 1)
            {
                levelComplete = true;
                playerMoney.playerMoney += level * 100;
            }

            yield return new WaitForSeconds(spawnWait);

            

            
        }
    }

   
}
