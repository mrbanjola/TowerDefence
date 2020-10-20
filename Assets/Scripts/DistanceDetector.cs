using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDetector : MonoBehaviour
{
    float distance;
    float enemyDistance;
    Vector3 enemyPosition;
    Vector3 towerPosition;
    Vector3 distanceVector;
    public GameObject targetEnemy;
    ParticleSystem gun;
    
    // Start is called before the first frame update
    void Start()
    {
        gun = gameObject.GetComponent<ParticleSystem>();
        
        
       
        
    }

    // Update is called once per frame
    void Update()
    {
        targetEnemy = SetTargetEnemy();
        if (targetEnemy == null)
        {
            distance = 1000;
        } else
        {
            GetDistanceToEnemy(targetEnemy);
        }
        FireGuns();


    }

    public GameObject SetTargetEnemy()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.GetLength(0) == 0)
        {
            return null;
        }
        distance = 1000f;
        GameObject closestEnemy = null;

        

        foreach(GameObject enemy in enemies)
        {
            float newDistance = Vector3.Distance(towerPosition, enemy.transform.position);
            if (newDistance < distance) {

                distance = newDistance;
                closestEnemy = enemy;

            }


        }

        return closestEnemy;


    }

    private void FireGuns()
    {
        var emissionModule = gun.emission;
        if (distance <= 30f)
        {
            emissionModule.enabled = true;

        }
        else
        {
            emissionModule.enabled = false;
        }
    }

    private void GetDistanceToEnemy(GameObject enemy)
    {
        towerPosition = transform.position;
        enemyPosition = enemy.transform.position;

        distanceVector = enemyPosition - towerPosition;
        enemyDistance = distanceVector.magnitude;
        
    }
}
