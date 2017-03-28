using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public enum FORMSTATES
    {
        STAY, BLOB, REVOLVE, LINE
    }

    public FORMSTATES unitStates;

    public float thrust;
    public float jumpStrength = 2.0f;
    public Rigidbody rb;
    public float turnSpeed = 50.0f;
    public float shootStrength = 3.0f;
    float distToGround;
    List<GameObject> objects;
    float rotateSpeed = 1.5f;

    float knockbackDmg = 2;

    public string getEnumState()
    {
        return unitStates.ToString();
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
            //float rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(0, rotation, 0);

            return direction;
        }
        return transform.position;
    }

    void doShoot()
    {
        Vector3 point = MouseShoot();

        Rigidbody rb = gameObject.GetComponent<Selector>().selectorList[0].gameObject.GetComponent<Rigidbody>();
        rb.transform.position = transform.position + (transform.forward * 2);
        rb.AddForce(point * shootStrength, ForceMode.Impulse);

        //rb.gameObject.AddComponent<ParticleSystem>();

        rb.gameObject.GetComponent<UnitProperties>().isAttached = false;
        gameObject.GetComponent<Selector>().selectorList.RemoveAt(0);
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

    void OnCollisionEnter(Collision other)
    {
        float force = 100;

        // run into an enemy knockback and small damage
        if (other.gameObject.tag == "Enemy")
        {
            Vector3 dir = other.contacts[0].point - transform.position;
            dir = -dir.normalized;

            gameObject.GetComponent<Rigidbody>().AddForce(dir * force, ForceMode.Impulse);

            //take small damage
            IDamage thePlayer = gameObject.GetComponent<IDamage>();
            thePlayer.TakeDamage(knockbackDmg);
        }
    }

    void Start()
    {
        objects = gameObject.GetComponent<Selector>().selectorList;
        rb = GetComponent<Rigidbody>();
        unitStates = FORMSTATES.BLOB;
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    void Update () {
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 125.0f;
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

        if (Input.GetKey("space") && IsGrounded())
        {
            rb.AddForce(new Vector3(0,jumpStrength,0), ForceMode.Impulse);
        }

        if (unitStates == FORMSTATES.LINE)
        {            
            objects = gameObject.GetComponent<Selector>().selectorList;
            foreach (GameObject obj in objects)
            {              
                if (obj != null)
                {

                }
            }
        }

        if (unitStates == FORMSTATES.REVOLVE)
        {
            objects = gameObject.GetComponent<Selector>().selectorList;
            foreach (GameObject obj in objects)
            {
                if (obj != null)
                {
                    obj.transform.position = gameObject.transform.position +
                        (obj.transform.position - gameObject.transform.position).normalized *
                        1.0f;
                    obj.transform.RotateAround(
                        gameObject.transform.position + (transform.up * 6), 
                        Vector3.up, 
                        100 * rotateSpeed * Time.deltaTime);
                }
            }
        }

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(1)) //shoot ur units
        {

            if (unitStates == FORMSTATES.BLOB || unitStates == FORMSTATES.REVOLVE)
            {
                //RotateToMouse();
                doShoot();                
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
