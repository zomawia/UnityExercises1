using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public GameObject player;
    public GameObject bulletPrefab;

    public float launchForce = 30.0f;

    public Transform firePoint;

    public float firingInterval = 1.0f;
    private float firingTimer;

    public float firingRadius = 8.0f;

    bool isPlayerInRange()
    {
        return Vector3.Distance(player.transform.position, transform.position) <= firingRadius;
    }

    void Start()
    {        
        firingTimer = firingInterval;
    }

	// Update is called once per frame
	void Update () {
        bool inRange = isPlayerInRange();

        

        firingTimer -= Time.deltaTime;

        if (firingTimer <= 0.0f && inRange)
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
