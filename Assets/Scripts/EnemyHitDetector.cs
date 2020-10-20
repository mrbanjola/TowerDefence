using UnityEngine;
using TMPro;

public class EnemyHitDetector : MonoBehaviour
{
    int enemyHealth = 10;
    AudioSource hitSound;

    [Header("Enemy FX")]
    [SerializeField] ParticleSystem hitParticles;
    [SerializeField] public ParticleSystem deathParticles;

    PlayerMoney playerMoney;
    MoneyTracker moneyTracker;

   
   
    void Start()
    {
        hitSound = gameObject.GetComponent<AudioSource>();
        playerMoney = FindObjectOfType<PlayerMoney>();
        moneyTracker = FindObjectOfType<MoneyTracker>();
        

    }

    
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        enemyHealth--;
        hitParticles.Play();
        hitSound.Play();
        
        if (enemyHealth <= 0)
        {
            Instantiate(deathParticles,transform.position,Quaternion.identity);
            Destroy(gameObject.transform.parent.gameObject);

            playerMoney.playerMoney += 50; // todo Make less stupid way to increase money
            moneyTracker.UpdateMoney(playerMoney.playerMoney);




        }
    }
}
