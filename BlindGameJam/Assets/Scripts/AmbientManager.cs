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
    public AudioSource cut;
    public AudioSource dirgroan;
    public AudioSource dirend;

    public ParticleSystem ash;
    public AudioSource crowd2;

    public AudioSource intro;

    private bool playonce = false;
    private bool playtwice = false;
    private bool playthrice = false;
    private bool playfourice = false;
    private bool playfivice = false;
    private bool sice = false;

	// Use this for initialization
	void Start () {
        crowd.Play();
        Invoke("Move", 7.5f);
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

        if (cut.isPlaying)
        {
            if (playfourice == false)
            {
                //crowd2.Play();
                ash.gameObject.SetActive(false);
                playfourice = true;
            }
            if (playfourice == true)
            {
                return;
            }
        }

        if (dirgroan.isPlaying)
        {
            if (playfivice == false)
            {
                groan.Play();
                playfivice = true;
            }
            if (playfivice == true)
            {
                return;
            }
        }

        if (dirend.isPlaying)
        {
            if (sice == false)
            {
                crowd2.Stop();
                footsteps.Play();
                sice = true;
            }
            if (sice == true)
            {
                footsteps.Stop();
                crowd2.Stop();
                return; 
            }
        }

        if (intro.isPlaying)
        {
            ash.gameObject.SetActive(true);
        }
    }

    private void Move()
    {
        crowd.Stop();
        move.Play();
    }
}
