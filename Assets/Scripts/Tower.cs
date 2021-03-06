﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] Transform movingPart;
    Transform targetEnemy;
    [SerializeField] DistanceDetector distanceDetector;
    public ParticleSystem fireParticles;

    public WorldBlock baseWorldBlock;


    private void Start()
    {
        fireParticles = GetComponentInChildren<ParticleSystem>();    }

    // Update is called once per frame
    void Update()
    {
        TargetEnemy();

    }


   

    void TargetEnemy()
    {   try
        {
            targetEnemy = distanceDetector.SetTargetEnemy().transform;
            movingPart.LookAt(targetEnemy);
        } catch
        {
            
        }
    }
}
