using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public List<GameObject> enableOnAwake = new List<GameObject>();
	// Use this for initialization
	void Start () {
        for (int i = 0; i < enableOnAwake.Count; i++)
        {
            enableOnAwake[i].SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
