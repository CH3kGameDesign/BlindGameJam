using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    [Header ("Variables")]
    public float swingGate;
    public float swingTimer;
    public float blockTimer;

    [Header ("Prefabs")]
    public List<GameObject> swingSounds = new List<GameObject>();
    public List<GameObject> blockSounds = new List<GameObject>();
    public List<GameObject> killSounds = new List<GameObject>();

    [HideInInspector]
    public bool swung;
    [HideInInspector]
    public int swing;

    [HideInInspector]
    public int block;
    
    private float blockTime;
    private float swingTime;

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        swung = false;
        block = -1;
    }
	
	// Update is called once per frame
	void Update () {

        
        SwingUpdate();
        BlockUpdate();
    }
    
    void SwingUpdate()
    {
        int layerMask = LayerMask.GetMask("Enemy");
        if (swingTime > swingTimer)
        {
            if (Input.GetAxis("Mouse X") > swingGate)
            {
                swing = 1;
                swingTime = 0;
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.right, out hit, 10, layerMask))
                {
                    HitEnemy(hit.transform);
                }
            }
            else if (Input.GetAxis("Mouse X") < -swingGate)
            {
                swing = 0;
                swingTime = 0;
                RaycastHit hit;
                if (Physics.Raycast(transform.position, -transform.right, out hit, 10, layerMask))
                {
                    HitEnemy(hit.transform);
                }
            }
            else
            {
                swung = false;
                swing = -1;
            }
        }


        if (swung == false && swing != -1)
        {
            Debug.Log("Swing " + swing);
            swung = true;
            Instantiate(swingSounds[swing], transform.position, transform.rotation);
        }
        
        swingTime += Time.deltaTime;
    }

    void HitEnemy (Transform enemy)
    {
        Instantiate(killSounds[1], enemy.position, enemy.rotation);
        Destroy(enemy.gameObject);
    }

    void BlockUpdate ()
    {
        int layerMask = LayerMask.GetMask("Knife");
        if (blockTime > blockTimer)
            block = -1;

        if (Input.GetMouseButtonDown(0))
        {
            block = 0;
            blockTime = 0;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.right, out hit, 10, layerMask))
            {
                HitEnemy(hit.transform);
            }
            Instantiate(blockSounds[block], transform.position, transform.rotation);
        }
        if (Input.GetMouseButtonDown(1))
        {
            block = 1;
            blockTime = 0;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -transform.right, out hit, 10, layerMask))
            {
                HitEnemy(hit.transform);
            }
            Instantiate(blockSounds[block], transform.position, transform.rotation);
            
        }

        blockTime += Time.deltaTime;
    }
}
