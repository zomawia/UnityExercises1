using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoints : MonoBehaviour {

    public GameObject player;

    bool hasJoint;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<Rigidbody>() != null && !hasJoint)
            {
                gameObject.AddComponent<FixedJoint>();
                gameObject.GetComponent<FixedJoint>().connectedBody = player.GetComponent<Rigidbody>();
                hasJoint = true;
            }
        }
    }
}
