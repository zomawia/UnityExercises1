﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : _BaseAIController
{
    public GameObject bulletPrefab;

    public float launchForce = 30.0f;

    public Transform firePoint;

    public float firingInterval = 1.0f;
    private float firingTimer;

    public float firingRadius = 8.0f;

    public override void Start() 
    {
        base.Start();
        firingTimer = firingInterval;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        firingTimer -= Time.deltaTime;

        if (firingTimer <= 0.0f && isPlayerInRange())
        {
            firingTimer = firingInterval;
            GameObject baby = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            baby.GetComponent<Rigidbody>().AddForce(firePoint.forward * launchForce, ForceMode.Impulse);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, firingRadius);
    }
}
