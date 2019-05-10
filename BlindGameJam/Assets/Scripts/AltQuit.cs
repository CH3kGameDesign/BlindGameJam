using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltQuit : MonoBehaviour {

	void Update () {
		if (Input.GetKey(KeyCode.Mouse1))
        {
            Application.Quit();
        }
	}
}
