using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject prefab;

    public float spawnInterval = 1.0f;
    private float spawnTimer;

    public float spawnFuzzy = 0.5f;

    public static int livingSpawns;
    public int maxLivingSpawns = 5;

	// Use this for initialization
	void Start () {
        spawnTimer = spawnInterval;
	}
	
	// Update is called once per frame
	void Update () {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer < 0 && livingSpawns < maxLivingSpawns)
        {
            spawnTimer = spawnInterval + Random.Range(-spawnFuzzy, spawnFuzzy);
            GameObject baby = Instantiate(prefab);
            baby.transform.position.Set(0, 25, 0);
            //baby.AddComponent<SpawnerTracker>().origin = this;

            livingSpawns++;
        }
	}
}
