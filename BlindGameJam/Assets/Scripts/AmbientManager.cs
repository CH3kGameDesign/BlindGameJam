using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientManager : MonoBehaviour {

    public AudioSource crowd;
    public AudioSource move;
    public AudioSource groan;
    public AudioSource chair;
    public AudioSource footsteps;
    public AudioSource slap;

    public AudioSource armor;
    public AudioSource wood;
    public AudioSource air;
    public AudioSource flesh;
    public AudioSource collide;
    public AudioSource unsheathe;

    public ParticleSystem ash;

	// Use this for initialization
	void Start () {
        crowd.Play();
        Invoke("Move", 6f);
        Invoke("Groan", .1f);
        Invoke("Chair", .1f);
        Invoke("Footsteps", .1f);
        Invoke("Slap", .1f);
        Invoke("Unsheathe", .1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Move()
    {
        crowd.Stop();
        move.Play();
    }

    void Groan()
    {

    }

    void Chair()
    {

    }

    void Footsteps()
    {

    }

    void Slap()
    {

    }

    void Unsheathe()
    {

    }
}
