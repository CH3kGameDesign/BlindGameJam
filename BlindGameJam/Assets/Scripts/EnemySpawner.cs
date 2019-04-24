using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [Header("Variables")]
    public float spawnTimer;
    [Header("GameObjects")]
    public List<GameObject> enemies = new List<GameObject>();

    private float spawnTime = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.childCount < 4 && spawnTime > spawnTimer)
        {
            int spawnPlace = Random.Range(0, 2);
            Instantiate(enemies[Random.Range(0, enemies.Count)], new Vector3(-15 + (30 * spawnPlace), 0, 0), transform.rotation, transform);
            spawnTime = Random.Range(-1, 0);
        }
        spawnTime += Time.deltaTime;
	}
}
