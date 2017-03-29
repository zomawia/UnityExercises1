using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour {
        
    //public GameObject ngo;
    private Text myText;
    private Text controls;
    private GameObject player;
    //PlayerController pc;
    PlayerHealth playerHealth;
    //string prevState, currState;

    //bool isStateChanged()
    //{
    //    return prevState != currState;
    //}   

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //currState = prevState = player.GetComponent<PlayerController>().getEnumState();
        //pc = player.GetComponent<PlayerController>();

        playerHealth = player.GetComponent<PlayerHealth>();
        GameObject newGO = new GameObject("myTextGO");
        GameObject controlsGO = new GameObject("controlsGO");
        controlsGO.transform.SetParent(transform);
        newGO.transform.SetParent(transform);

        Font Arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        controls = controlsGO.AddComponent<Text>();
        controls.rectTransform.position = new Vector3(1200, 20, 60);
        controls.font = Arial;
        controls.material = Arial.material;
        controls.color = Color.black;
        controls.text = "W/S: move, A/S: turn, Q/E: adjust spin";

        myText = newGO.AddComponent<Text>();
        myText.rectTransform.position = new Vector3(60, 0, 0);
        myText.font = Arial;
        myText.material = Arial.material;
        myText.text = "Health: " + playerHealth.healthValue;
    }

    void Update()
    {
        //currState = pc.getEnumState();
        //if (isStateChanged() == true)
        //{
        //    prevState = currState;
        //    myText.text = "Health: " + playerHealth.healthValue + " Form: " + currState;
        //}
        myText.text = "Health: " + playerHealth.healthValue;
    }
}
