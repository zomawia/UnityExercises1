using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    private Vector3 followOffset;
    Vector3 prevOffset;
	IEnumerator cor;

	float duration = 0.05f;
	float magnitude = 1.0f;

	public bool receivedDmg;

    Vector3 getShake()
    {
        var retval = new Vector3();
		retval.x += Mathf.PerlinNoise(-1, 1);
		retval.y += Mathf.PerlinNoise(-1, 1);
		retval.z += Mathf.PerlinNoise(-1, 1);
        return retval;
    }

    private void Start()
    {        
        followOffset = transform.position - target.position;

		receivedDmg = false;

        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player").transform;
    }

	IEnumerator doShake()
	{
		float elasped = 0.0f;
		Vector3 originalPos = transform.position;

		while (elasped < duration) 
		{
			elasped += Time.deltaTime;

			float percentComplete = elasped / duration;
			float damper = 1.0f - Mathf.Clamp (4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

			float x = Mathf.PerlinNoise (-1, 1);
			float z = Mathf.PerlinNoise (-1, 1);

			x *= magnitude * damper;
			z *= magnitude * damper;

			transform.position = new Vector3 (x, originalPos.y, z);

			yield return null;
		}

		transform.position = originalPos;
	}

    // Update is called once per frame
    private void Update()
    {		
		if (receivedDmg == true) 
		{
			//cor = doShake();
			//StartCoroutine (cor);
			receivedDmg = false;
		}

		else
		{
			transform.position = Vector3.Lerp (transform.position, target.position + followOffset, Time.deltaTime * 2);
		}

        // if player is destroyed
        if (target == null)
            target = transform;
    }
}
