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

    public AudioSource unsheathe;

    public AudioSource producer;
    public AudioSource director;
    public AudioSource narrator;
    public AudioSource dirgroan;

    public ParticleSystem ash;

    private bool playonce = false;
    private bool playtwice = false;
    private bool playthrice = false;
    private bool playfourice = false;

	// Use this for initialization
	void Start () {
        crowd.Play();
        Invoke("Move", 6f);
        Invoke("Chair", .1f);
        Invoke("Footsteps", .1f);
        Invoke("Slap", .1f);
        Invoke("Unsheathe", .1f);
	}
	
	// Update is called once per frame
	void Update () {
        if (narrator.isPlaying)
        {
            if (playonce == false)
            {
                unsheathe.Play();
                playonce = true;
            }
            if (playonce == true)
            {
                return;
            }
        }

        if (director.isPlaying)
        {
            if (playtwice == false)
            {
                footsteps.Play();
                playtwice = true;
            }
            if (playtwice == true)
            {
                return;
            }
        }

        if (producer.isPlaying)
        {
            if (playthrice == false)
            {
                slap.Play();
                playthrice = true;
            }
            if (playthrice == true)
            {
                return;
            }
        }
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
