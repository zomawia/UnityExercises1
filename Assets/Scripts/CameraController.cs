using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    private Vector3 followOffset;
    Vector3 prevOffset;

    Vector3 doShake()
    {
        var retval = new Vector3();
        retval.x += Random.Range(-2, 2);
        retval.y += Random.Range(-2, 2);
        retval.z += Random.Range(-2, 2);
        return retval;
    }

    private void Start()
    {        
        followOffset = transform.position - target.position;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + followOffset, Time.deltaTime * 2);

    }
}
