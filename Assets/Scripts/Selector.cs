using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour {

    public List<GameObject> selectorList;
    GameObject activeObject;
    bool changeActive;

    void Activate(GameObject obj)
    {
        obj.SetActive(true);
    }

    void deActivate(GameObject obj)
    {
        obj.SetActive(false);        
    }

    // Use this for initialization
    void Start ()
    {
        changeActive = false;

        foreach (var GameObject in selectorList)
        {
            deActivate(GameObject);
        }

        activeObject = selectorList[0];

    }
	
	// Update is called once per frame
	void Update () {
        changeActive = Input.GetKeyDown("space");

        foreach (var item in selectorList)
        {
            if (item.activeSelf == true)
            {
                item.SetActive(false);
            }
        }

        activeObject.SetActive(true);

        if (changeActive)
        {

            Debug.Log("hello");
            activeObject = selectorList[Random.Range(0, 3)];
            changeActive = false;
        }

	}
}
