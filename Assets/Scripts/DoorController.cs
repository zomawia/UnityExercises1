using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour, IInteractable {
    public bool isInteractable
    {
        get
        {
            return true;
        }

    }
    public void Interact()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

}
