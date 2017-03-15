using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToggle : MonoBehaviour {

    public GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        door.GetComponent<IInteractable>().Interact();
    }
}
