using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    enum FORMSTATES
    {
        BLOB, STAY, LINE
    }

    FORMSTATES unitStates;

    public float thrust;
    public float jumpStrength = 2.0f;
    public Rigidbody rb;

    public float turnSpeed = 50f;

    public float shootStrength = 5.0f;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        
        unitStates = FORMSTATES.BLOB;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp("e"))
        {
            unitStates++;
        }
        else if (Input.GetKeyUp("q"))
            {
                unitStates--;
            }

        if (Input.GetKey("w"))
        {

            rb.AddForceAtPosition(
        }

        if (Input.GetKey("s"))
        {
            rb.AddForce(Vector3.forward * -thrust, ForceMode.Impulse);
        }

        if (Input.GetKey("a"))
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }

        if (Input.GetKey("d"))
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }

        if (Input.GetKey("space"))
        {
            rb.AddForce(new Vector3(0,jumpStrength,0), ForceMode.Impulse);
        }

        if (Input.GetMouseButtonDown(0)) //shoot ur units
        {

            if (unitStates == FORMSTATES.BLOB)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                Ray playerRay = new Ray(transform.position, ray.origin);

                gameObject.GetComponent<Selector>().selectorList[0].gameObject.GetComponent<Rigidbody>().AddForce(playerRay.direction * shootStrength, ForceMode.Impulse);
                gameObject.GetComponent<Selector>().selectorList[0].gameObject.GetComponent<UnitProperties>().isAttached = false;
                gameObject.GetComponent<Selector>().selectorList.RemoveAt(0);
            }

            if (unitStates == FORMSTATES.LINE)
            {

            }

            if (unitStates == FORMSTATES.STAY)
            {

            }
        }

        Debug.DrawLine(transform.forward, transform.forward * 55);
    }
}
