using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour {

    public List<GameObject> selectorList;
    GameObject activeObject;

    UnitProperties isUnitAttached;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Unit" 
            && other.gameObject.GetComponent<UnitProperties>().isAttached == false)
        {
            other.gameObject.GetComponent<UnitProperties>().isAttached = true;
            other.gameObject.GetComponent<UnitProperties>().myHero = gameObject;
            selectorList.Add(other.gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {

        foreach (GameObject item in selectorList)
        {
           
        }

	}
}
