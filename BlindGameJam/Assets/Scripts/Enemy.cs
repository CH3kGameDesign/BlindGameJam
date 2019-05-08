using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    [Header("Variables")]
    public float movSpeed;
    public float attackDistance;
    public float attackSpeed;

    [Header("Sound Variables")]
    public float stepSpeed;

    [Header("GameObjects")]
    public List<GameObject> warSounds = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> stepSounds = new List<GameObject>();

    private float stepTime;
    private int stepNo;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
        else if (transform.position.x < -0.6)
            transform.position += new Vector3(movSpeed * Time.deltaTime, 0, 0);
        else if (transform.position.z > 0.6)
            transform.position -= new Vector3(0, 0, movSpeed * Time.deltaTime);
        else if (transform.position.z < -0.6)
            transform.position += new Vector3(0, 0, movSpeed * Time.deltaTime);
        else
        {
            stepTime = 0;
            if (transform.childCount == 0)
            {
                Instantiate(warSounds[Random.Range(0, warSounds.Count)], transform);
                Invoke("Attack", attackSpeed);
            }
        }
    }

    void Attack()
    {
        SceneManager.LoadScene(1);
    }
}
