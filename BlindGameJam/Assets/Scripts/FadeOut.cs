using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour {

    [Header("GameObjects")]
    public List<GameObject> enableOnDestroy = new List<GameObject>();

    [Header("Variables")]
    public float fadeSpeed;
    public float destroyTimer;

	// Use this for initialization
	void Start () {
        if (destroyTimer == 0)
            destroyTimer = fadeSpeed * 10;
        Invoke("Destroy", destroyTimer);
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, Color.clear, fadeSpeed * Time.deltaTime);

        if (GetComponent<SpriteRenderer>().color == Color.clear)
            Destroy(this.gameObject);
    }

    private void Destroy()
    {
        for (int i = 0; i < enableOnDestroy.Count; i++)
        {
            enableOnDestroy[i].SetActive(true);
        }
        Destroy(this.gameObject);
    }
}

