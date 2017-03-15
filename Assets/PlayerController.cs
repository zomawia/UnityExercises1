using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float thrust;
    public Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("w"))
        {
            rb.AddTorque(thrust,0,0);
        }

        if (Input.GetKey("s"))
        {
            rb.AddTorque(-thrust, 0, 0);
        }

        if (Input.GetKey("a"))
        {
            rb.AddTorque(0, 0, thrust);
        }

        if (Input.GetKey("d"))
        {
            rb.AddTorque(0, 0, -thrust);
        }
    }
}
