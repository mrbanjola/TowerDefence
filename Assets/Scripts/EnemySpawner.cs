using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy and Enemy Group")]
    [SerializeField] GameObject enemy;
    [SerializeField] Transform enemies;

    [Header("Spawn Settings")]
    [SerializeField] float secondsBetweenSpawns = 3f;
    [SerializeField] public int heightAdjust = 10;

    AudioSource spawnSound;

    // Start is called before the first frame update
    void Start()
    {
        spawnSound = GetComponent<AudioSource>();

        StartCoroutine(SpawnEnemies());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < 100; i++)
        {
            Instantiate(enemy,FindObjectOfType<PathFinder>().getPath()[0] + new Vector3Int(0,heightAdjust,0), Quaternion.identity ,enemies);
            spawnSound.Play();
            if (secondsBetweenSpawns >= .4f)
            {
                secondsBetweenSpawns = secondsBetweenSpawns - 0.03f;
            }
           

            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

   
}
