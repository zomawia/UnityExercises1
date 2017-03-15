using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropelForward : MonoBehaviour {

    private Rigidbody rbody;
    public float propulsionForce = 100.0f;

	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        rbody.AddForce(transform.forward * propulsionForce);
	}
}
