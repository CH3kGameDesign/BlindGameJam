using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {

    public Transform ScriptedDialogueHolder;
    public Transform BackgroundVoicesHolder;

    private AudioSource[] ScrSource;
    private AudioSource[] BacSource;

    [HideInInspector]
    public int lastDiaLine = -1;
    [HideInInspector]
    public int EndOnLine = -1;
    [HideInInspector]
    public bool stoppedPlaying = true;

    // Use this for initialization
    void Start () {
        /*
        ScrSource = ScriptedDialogueHolder.GetComponentsInChildren<AudioSource>();
        BacSource = BackgroundVoicesHolder.GetComponentsInChildren<AudioSource>();
        */
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < ScriptedDialogueHolder.childCount; i++)
        {
            if (ScriptedDialogueHolder.GetChild(i).GetComponent<AudioSource>().isPlaying == true)
                return;
        }
        if (lastDiaLine < EndOnLine)
        {
            ScriptLines(lastDiaLine + 1);
        }
        else
            stoppedPlaying = true;

    }

    public void ScriptLines (int line)
    {
        stoppedPlaying = false;
        if (line == -1)
        {
            line = lastDiaLine + 1;
        }
        ScriptedDialogueHolder.GetChild(line).gameObject.SetActive(true);
        lastDiaLine = line;
    }

    public void BackgroundLines (int line)
    {
        BacSource[line].Play();
    }
}
