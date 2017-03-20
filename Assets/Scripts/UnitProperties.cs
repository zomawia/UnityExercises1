using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitProperties : MonoBehaviour {

    int moveSpeed = 4;
    int rotationSpeed = 6;

    float maxFollow = 20;
    float minFollow = 1;               

    public bool isAttached;
    public GameObject myHero;

    Transform myTransform;
    Transform myTarget;

    //NavMeshAgent agent;
    

    void Awake()
    {
        myTransform = transform; //cache me ousside
    }

	// Use this for initialization
	void Start ()
    {
        myTarget = GameObject.FindWithTag("Player").transform; //target the player
        //agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
		if (isAttached == true)
        {
            //gameObject.GetComponent<Rigidbody>().isKinematic = true;
            float distance = Vector3.Distance(myTransform.position, myTarget.position);

            myTransform.rotation = Quaternion.Slerp(
                    myTransform.rotation,
                    Quaternion.LookRotation(myHero.GetComponent<Transform>().position - myTransform.position),
                    rotationSpeed * Time.deltaTime);

            if (distance < maxFollow && distance > minFollow)
            {
                myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
                //agent.destination = myTarget.position;
            }
                        
        }
	}
}
