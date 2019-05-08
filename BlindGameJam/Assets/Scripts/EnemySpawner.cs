using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [Header("Variables")]
    public float spawnTimer;
    [Header("GameObjects")]
    public List<GameObject> enemies = new List<GameObject>();
    public List<Transform> spawnPoint = new List<Transform>();
    [Space (20)]
    [Header("SoundGameobjects")]
    public List<GameObject> stepSoundsSide = new List<GameObject>();
    public List<GameObject> stepSoundsFront = new List<GameObject>();
    public List<GameObject> stepSoundsBack = new List<GameObject>();
    [Space (10)]
    public List<GameObject> warSoundsSide = new List<GameObject>();
    public List<GameObject> warSoundsFront = new List<GameObject>();
    public List<GameObject> warSoundsBack = new List<GameObject>();

    private float spawnTime = 0;

    public bool spawnEnemies;
    [HideInInspector]
    public bool enemyWin = false;

    [HideInInspector]
    public int enemiesSpawned = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.childCount < 4 && spawnTime > spawnTimer && spawnEnemies == true)
        {
            int spawnPlace = Random.Range(0, 4);
            if (spawnPlace >= 2)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    if (transform.GetChild(i).name == "2" || transform.GetChild(i).name == "3")
                        spawnPlace = Random.Range(0, 2);
                }
            }

            GameObject GO = Instantiate(enemies[Random.Range(0, enemies.Count)], spawnPoint[spawnPlace].position, spawnPoint[spawnPlace].rotation, transform);
            enemiesSpawned++;
            GO.name = spawnPlace.ToString();

            if (spawnPlace < 2)
            {
                GO.GetComponent<Enemy>().stepSounds = stepSoundsSide;
                GO.GetComponent<Enemy>().warSounds = warSoundsSide;
            }
            if (spawnPlace == 2)
            {
                GO.GetComponent<Enemy>().stepSounds = stepSoundsBack;
                GO.GetComponent<Enemy>().warSounds = warSoundsBack;
            }
            if (spawnPlace == 3)
            {
                GO.GetComponent<Enemy>().stepSounds = stepSoundsFront;
                GO.GetComponent<Enemy>().warSounds = warSoundsFront;
            }

            spawnTime = Random.Range(-1, 0);
        }
        spawnTime += Time.deltaTime;
	}
}
