using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour {
        
    //public GameObject ngo;
    private Text myText;
    private GameObject player;
    PlayerController pc;
    string prevState, currState;

    bool isStateChanged()
    {
        return prevState != currState;
    }   

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currState = prevState = player.GetComponent<PlayerController>().getEnumState();
        pc = player.GetComponent<PlayerController>();

        GameObject newGO = new GameObject("myTextGO");
        newGO.transform.SetParent(transform);

        myText = newGO.AddComponent<Text>();
        Font Arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        myText.rectTransform.position = new Vector3(60, 0, 0);
        myText.font = Arial;
        myText.material = Arial.material;
        myText.text = "Form: " + currState;
    }

    void Update()
    {
        currState = pc.getEnumState();
        if (isStateChanged() == true)
        {
            prevState = currState;
            myText.text = "Form: " + currState;
        }        
    }
}
