using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    // Runs during initialisation.
    private void Start()
    {
        Invoke("ChangeScene", 25f);
    }

    // Update is called once per frame
    void Update () {
		if (Input.anyKey)
        {
            SceneManager.LoadScene(1);
        }
	}

    void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}
