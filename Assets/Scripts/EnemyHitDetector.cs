using UnityEngine;
using TMPro;

public class EnemyHitDetector : MonoBehaviour
{
    
    
    AudioSource hitSound;

    Tower tower;

    [Header("Enemy FX")]
    [SerializeField] ParticleSystem hitParticles;
    [SerializeField] public ParticleSystem deathParticles;

    [Header("Enemy Data")]
    [SerializeField] int enemyHealth = 10;
    int enemyBaseHealth;
    
    [SerializeField] public int cashPerKill = 10;


    PlayerMoney playerMoney;
    MoneyTracker moneyTracker;
    [Header("Weapon data(Don't change)")]
    public WeaponData weaponData;

    ScoreTracker scoreTracker;

    TowerKills towerKills;

   
   
    void Start()
    {
        hitSound = gameObject.GetComponent<AudioSource>();
        playerMoney = FindObjectOfType<PlayerMoney>();
        moneyTracker = FindObjectOfType<MoneyTracker>();
        scoreTracker = FindObjectOfType<ScoreTracker>();
        enemyBaseHealth = enemyHealth;
        towerKills = FindObjectOfType<TowerKills>();



    }

    
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        weaponData = other.GetComponent<WeaponData>();
        enemyHealth -= weaponData.weaponDamage;
        hitParticles.Play();
        hitSound.Play();
        
        if (enemyHealth <= 0)
        {
            Instantiate(deathParticles,transform.position,Quaternion.identity);
            Destroy(gameObject);

            playerMoney.playerMoney += cashPerKill;
            moneyTracker.UpdateMoney(playerMoney.playerMoney);
            scoreTracker.score += enemyBaseHealth;
            scoreTracker.UpdateScore();
            weaponData.kills++;
            






        }
    }
}
