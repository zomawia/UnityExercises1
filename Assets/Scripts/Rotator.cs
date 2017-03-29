using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    public float HealthBoost = 5.0f;
    public GameObject particles;

    public void playParticles()
    {
        if (particles != null)
        {
            GameObject trail = Instantiate(particles, transform.position, transform.rotation);
            //trail.transform.parent = transform;
        }
    }

    void Awake()
    {
        particles = (GameObject)Resources.Load("Sparkles");
    }

	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
