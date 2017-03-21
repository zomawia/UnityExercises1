using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _BaseAIController : MonoBehaviour {

    public GameObject player;

    float viewRadius = 10;

    public bool isPlayerInRange()
    {
        return Vector3.Distance(player.transform.position, transform.position) <= viewRadius;
    }

    void LookAt()
    {
        transform.forward = (player.transform.position - transform.position).normalized;
    }

    // Use this for initialization
    public virtual void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    public virtual void Update () {
        if (isPlayerInRange())
        {
            transform.forward = (player.transform.position - transform.position).normalized;
        }
	}
}
