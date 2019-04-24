using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour {

    [Header("Variables")]
    public float fadeSpeed;
    public float fadeOutTimer;

	// Use this for initialization
	void Start () {
        if (GetComponent<FadeOut>() != null)
            GetComponent<FadeOut>().enabled = false;
        GetComponent<SpriteRenderer>().color = Color.clear;
        if (fadeOutTimer != 0)
            Invoke("FadeOutActivate", fadeOutTimer);
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, Color.white, fadeSpeed * Time.deltaTime);
	}

    void FadeOutActivate ()
    {
        if (GetComponent<FadeOut>() != null)
            GetComponent<FadeOut>().enabled = true;
        GetComponent<FadeIn>().enabled = false;
    }
}
