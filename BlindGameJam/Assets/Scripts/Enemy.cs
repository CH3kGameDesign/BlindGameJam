using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [Header("Variables")]
    public float movSpeed;
    public float attackDistance;

    [Header("Sound Variables")]
    public float stepSpeed;

    [Header("GameObjects")]
    public List<GameObject> stepSounds = new List<GameObject>();

    private float stepTime;
    private int stepNo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (stepTime > stepSpeed)
        {
            Instantiate(stepSounds[stepNo], transform.position, transform.rotation);
            stepNo++;
            if (stepNo > stepSounds.Count - 1)
                stepNo = 0;
            stepTime = 0;
        }

        stepTime += Time.deltaTime;

        if (transform.position.x > 0.6)
            transform.position -= new Vector3(movSpeed * Time.deltaTime, 0, 0);
        if (transform.position.x < -0.6)
            transform.position += new Vector3(movSpeed * Time.deltaTime, 0, 0);
    }
}
