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

    void RotateToMouse()
    {
        Vector3 v3T = Input.mousePosition;
        v3T.z = Mathf.Abs(Camera.main.transform.position.y - transform.position.y);
        v3T = Camera.main.ScreenToWorldPoint(v3T);
        v3T -= transform.position;
        v3T = v3T * 10000.0f + transform.position;
        transform.LookAt(v3T);
    }

    Vector3 MouseShoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, new Vector3(0, 0.5f, 0));

        float distance;
        if (plane.Raycast(ray, out distance))
        {
            Vector3 target = ray.GetPoint(distance);
            Vector3 direction = target - transform.position;
            float rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, rotation, 0);

            return direction;
        }
        return transform.position;
    }

    // Update is called once per frame

    void Update () {
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        transform.Translate(0, 0, z);
        transform.Rotate(0, x, 0);

        if (Input.GetKeyUp("e"))
        {
            unitStates++;
        }

        else if (Input.GetKeyUp("q"))
        {
            unitStates--;
        }

        if (Input.GetKey("space"))
        {
            rb.AddForce(new Vector3(0,jumpStrength,0), ForceMode.Impulse);
        }

        if (Input.GetMouseButtonDown(0)) //shoot ur units
        {

            if (unitStates == FORMSTATES.BLOB)
            {
                //RotateToMouse();
                Vector3 point = MouseShoot();

                Rigidbody rb = gameObject.GetComponent<Selector>().selectorList[0].gameObject.GetComponent<Rigidbody>();

                //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                //Ray playerRay = new Ray(transform.position, ray.origin);

                rb.AddForce(point * shootStrength, ForceMode.Impulse);
                rb.gameObject.GetComponent<UnitProperties>().isAttached = false;
                gameObject.GetComponent<Selector>().selectorList.RemoveAt(0);
            }

            if (unitStates == FORMSTATES.LINE)
            {

            }

            if (unitStates == FORMSTATES.STAY)
            {

            }
        }
    }
}
