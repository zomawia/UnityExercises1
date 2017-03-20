using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float thrust;
    public float jumpStrength = 2.0f;
    public Rigidbody rb;

    public float shootStrength = 5.0f;
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

        if (Input.GetKey("space"))
        {
            rb.AddForce(new Vector3(0,jumpStrength,0), ForceMode.Impulse);
        }

        if (Input.GetMouseButtonDown(0)) //shoot ur units
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Ray playerRay = new Ray(transform.position, ray.origin);                      

            gameObject.GetComponent<Selector>().selectorList[0].gameObject.GetComponent<Rigidbody>().AddForce(playerRay.direction * shootStrength, ForceMode.Impulse);
            gameObject.GetComponent<Selector>().selectorList[0].gameObject.GetComponent<UnitProperties>().isAttached = false;
            gameObject.GetComponent<Selector>().selectorList.RemoveAt(0);
            
        }

        Debug.DrawLine(transform.forward, transform.forward * 55);
    }
}
