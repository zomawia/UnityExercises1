using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public float explosionRadius = 12;
    public float explosionForce = 6;
    public float explosionUpward = 10;

    void OnCollisionEnter(Collision collision)
    {
        Collider[] nearbyColliders = Physics.OverlapSphere(transform.position, explosionRadius);

        for (int i = 0; i < nearbyColliders.Length; ++i)
        {
            //is it physics
            Rigidbody targetBody = nearbyColliders[i].GetComponent<Rigidbody>();
            if (targetBody != null)
            {
                targetBody.AddExplosionForce(explosionForce, transform.position, explosionRadius,
                    explosionUpward, ForceMode.Impulse);
            }

            //can it be damaged?
        }

        Destroy(gameObject);
    }
}