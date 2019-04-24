using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    [Header ("Variables")]
    public float swingGate;
    public float blockTimer;

    [Header ("Prefabs")]
    public List<GameObject> swingSounds = new List<GameObject>();
    public List<GameObject> blockSounds = new List<GameObject>();

    [HideInInspector]
    public bool swung;
    [HideInInspector]
    public int swing;

    [HideInInspector]
    public int block;

    private Vector3 prevPos;
    private float blockTime;

	// Use this for initialization
	void Start () {
        swung = false;
        block = -1;
        prevPos = Input.mousePosition;
    }
	
	// Update is called once per frame
	void Update () {


        SwingUpdate();
        BlockUpdate();
    }

    void SwingUpdate()
    {
        if ((Input.mousePosition.x - prevPos.x) > (swingGate * Time.deltaTime))
        {
            swing = 1;
        }
        else if ((Input.mousePosition.x - prevPos.x) < (-swingGate * Time.deltaTime))
        {
            swing = 0;
        }
        else
        {
            swung = false;
            swing = -1;
        }

        if (swung == false && swing != -1)
        {
            Debug.Log("Swing " + swing);
            swung = true;
            Instantiate(swingSounds[swing], transform.position, transform.rotation);
        }

        prevPos = Input.mousePosition;
    }

    void BlockUpdate ()
    {
        if (blockTime > blockTimer)
            block = -1;

        if (Input.GetMouseButtonDown(0))
        {
            block = 0;
            blockTime = 0;
            Instantiate(blockSounds[block], transform.position, transform.rotation);
        }
        if (Input.GetMouseButtonDown(1))
        {
            block = 1;
            blockTime = 0;
            Instantiate(blockSounds[block], transform.position, transform.rotation);
        }

        blockTime += Time.deltaTime;
    }
}
