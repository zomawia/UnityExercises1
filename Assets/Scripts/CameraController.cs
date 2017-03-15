using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    private Vector3 followOffset;

    private void Start()
    {
        followOffset = transform.position - target.position;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = target.position + followOffset;
    }
}
