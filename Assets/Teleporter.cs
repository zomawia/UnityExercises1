using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    public GameObject otherTeleporter;
    public GameObject destination;

    public float teleportationTimeout = 2.0f;
    public float teleportationTimer;	
	
	// Update is called once per frame
	void Update () {
        teleportationTimer -= Time.deltaTime;
	}

    void OnCollisionEnter(Collision collision)
    {
        //do nothing if still on cooldown
        if (teleportationTimer > 0.0f) { return; }

        teleportationTimer = teleportationTimeout;
        otherTeleporter.GetComponent<Teleporter>().teleportationTimer = teleportationTimer;

        //teleport the object
        collision.transform.position = otherTeleporter.transform.position;
    }

    public void ReceiveObject(GameObject package, float timeout)
    {
        package.transform.position = destination.transform.position;


    }
}
