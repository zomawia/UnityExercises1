using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour {

    public List<GameObject> selectorList;
    GameObject activeObject;

    UnitProperties isUnitAttached;

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
        foreach (var GameObject in selectorList)
        {
            deActivate(GameObject);
        }
    }

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
