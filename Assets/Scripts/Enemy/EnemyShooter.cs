using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : _BaseAIController
{
    public GameObject bulletPrefab;

    public float launchForce = 15.0f;

    public Transform firePoint;

    public float firingInterval = 1.0f;
    private float firingTimer;
    
    public float firingRadius = 7.0f;

    public virtual void LookAt()
    {
        transform.forward = (player.transform.position - transform.position).normalized;
    }

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

        //LookAt();

        if (firingTimer <= 0.0f && isPlayerInRange())
        {
            firingTimer = firingInterval;
            GameObject baby = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);            
            baby.GetComponent<Rigidbody>().AddForce(firePoint.forward * launchForce, ForceMode.Impulse);
        }
    }
}
