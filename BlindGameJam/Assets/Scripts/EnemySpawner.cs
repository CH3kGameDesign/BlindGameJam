using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [Header("Variables")]
    public float spawnTimer;
    [Header("GameObjects")]
    public List<GameObject> enemies = new List<GameObject>();
    public List<Transform> spawnPoint = new List<Transform>();
    [Space (10)]
    [Header("SoundGameobjects")]
    public List<GameObject> stepSoundsSide = new List<GameObject>();
    public List<GameObject> stepSoundsFront = new List<GameObject>();
    public List<GameObject> stepSoundsBack = new List<GameObject>();

    private float spawnTime = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.childCount < 4 && spawnTime > spawnTimer)
        {
            int spawnPlace = Random.Range(0, 4);
            GameObject GO = Instantiate(enemies[Random.Range(0, enemies.Count)], spawnPoint[spawnPlace].position, spawnPoint[spawnPlace].rotation, transform);
            if (spawnPlace < 2)
                GO.GetComponent<Enemy>().stepSounds = stepSoundsSide;
            if (spawnPlace == 2)
                GO.GetComponent<Enemy>().stepSounds = stepSoundsBack;
            if (spawnPlace == 3)
                GO.GetComponent<Enemy>().stepSounds = stepSoundsFront;

            spawnTime = Random.Range(-1, 0);
        }
        spawnTime += Time.deltaTime;
	}
}
