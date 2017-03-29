using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitProperties : MonoBehaviour {

    int moveSpeed = 4;
    int rotationSpeed = 6;

    //float maxFollow = 20;
    //float minFollow = 1;               

    public bool isAttached;
    public GameObject myHero;

    Transform myTransform;

    public GameObject TrailVFX;    



    void Awake()
    {
        myTransform = transform; //cache me ousside
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Unit")
        {
            Rigidbody myRB = gameObject.GetComponent<Rigidbody>();
            IDamage otherPlayer = other.gameObject.GetComponent<IDamage>();

            if (otherPlayer == null || (other.gameObject.tag == "Player" && isAttached))
            {
                return;
            }

            float dmg = myRB.velocity.magnitude * myRB.mass;
            if (dmg < 1) { return; }
            otherPlayer.TakeDamage(dmg);
            otherPlayer.displayDamage(dmg);
        }


    }

    public void playTrail()
    {
        if (TrailVFX != null)
        {
            GameObject trail = Instantiate(TrailVFX, transform.position, transform.rotation);
            //trail.transform.parent = transform;
        }
    }

    // Use this for initialization
    void Start ()
    {
        TrailVFX = (GameObject)Resources.Load("TrailEffect");                
    }
	
	// Update is called once per frame
	void Update () {
		//if (myHero != null) {
		//	if (isAttached == true && 
        //      myHero.GetComponent<PlayerController> ().unitStates == 
        //      PlayerController.FORMSTATES.BLOB) {
		//		//gameObject.GetComponent<Rigidbody>().isKinematic = true;
		//		gameObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
		//		float distance = Vector3.Distance (myTransform.position, myTarget.position);

		//		myTransform.rotation = Quaternion.Slerp (
		//			myTransform.rotation,
		//			Quaternion.LookRotation (myHero.GetComponent<Transform> ().position - myTransform.position),
		//			rotationSpeed * Time.deltaTime);

		//		if (distance < maxFollow && distance > minFollow) {
		//			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		//			//agent.destination = myTarget.position;
		//		}                        
		//	}
		//}


	}
}
