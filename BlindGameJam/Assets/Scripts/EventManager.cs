using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour {
    public DialogueManager DialogueManager;
    public Sword Sword;
    public EnemySpawner EnemySpawner;
    public GameObject[] ActivateOnCombat;

    [Header("Variables")]
    public float Event2Gate;
        private float Event2GateTimer = 0;
    public float Event4EnemyNumber;

    public int startEvent;
    [HideInInspector]
    public int lastEvent = 0;
    /*
     Events:
        1 OnAwake       - Lines ()
        2 OnMouseMove   - Lines ()
            ONFAIL      - Lines ()
        3 CONTINUED     - Lines ()
        4 Combat        - Lines () and Combat Start
            ONFAIL      - Lines () then back to 3
        5 Success       - Lines ()
        6 Death         - Lines () then game quit
     */

    // Use this for initialization
    void Awake () {
        GameObject[] EM = GameObject.FindGameObjectsWithTag("GameController");
        if (EM.Length != 1)
        {
            if (lastEvent != 0)
            {
                for (int i = 0; i < EM.Length; i++)
                {
                    if (EM[i] != this.gameObject)
                    {
                        EM[i].GetComponent<EventManager>().startEvent = startEvent;
                        Destroy(this.gameObject);
                    }
                }
            }
            else
            {
                for (int i = 0; i < EM.Length; i++)
                {
                    if (EM[i] != this.gameObject)
                    {
                        startEvent = EM[i].GetComponent<EventManager>().startEvent;
                        Destroy(EM[i]);
                    }
                }
            }
        }
        if (startEvent == 1)
            Event1();
        if (startEvent == 2)
            Event2();
        if (startEvent == 3)
            Event3();
        if (startEvent == 4)
            Event4();
        if (startEvent == 5)
            Event5();
        if (startEvent == 6)
            Event6();
        if (startEvent < 1 || startEvent > 6)
            Event1();
    }

    // Update is called once per frame
    void Update()
    {
        if (lastEvent == 1 && DialogueManager.stoppedPlaying == true)
        {
            if (Sword.swing != -1)
                Event2();
            if (Event2GateTimer > Event2Gate)
                Event2Fail();
            Event2GateTimer += Time.deltaTime;
        }
        if (lastEvent == 2 && DialogueManager.stoppedPlaying == true)
        {
            Event3();
        }
        if (lastEvent == 3 && DialogueManager.stoppedPlaying == true)
        {
            Event4();
        }

        if (lastEvent == 4 & DialogueManager.stoppedPlaying == true && EnemySpawner.enemiesSpawned != Event4EnemyNumber)
        {
            EnemySpawner.spawnEnemies = true;
            for (int i = 0; i < ActivateOnCombat.Length; i++)
            {
                ActivateOnCombat[i].SetActive(true);
            }
        }
        if (EnemySpawner.enemiesSpawned == Event4EnemyNumber && lastEvent == 4)
        {
            EnemySpawner.spawnEnemies = false;
        }
        if (lastEvent == 4 && EnemySpawner.enemyWin == true)
            Event4Fail();
        else if (lastEvent == 4 && EnemySpawner.transform.childCount == 0 && EnemySpawner.enemiesSpawned == Event4EnemyNumber)
        {
            Event5();
        }
        if (lastEvent == 40 && DialogueManager.stoppedPlaying == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (lastEvent == 5 && DialogueManager.stoppedPlaying == true)
        {
            EnemySpawner.spawnEnemies = true;
            for (int i = 0; i < ActivateOnCombat.Length; i++)
            {
                ActivateOnCombat[i].SetActive(true);
            }
        }
        if (lastEvent == 5 && EnemySpawner.enemyWin == true)
            Event6();
        if (lastEvent == 6 && DialogueManager.stoppedPlaying == true)
            SceneManager.LoadScene(0);
    }


    //OnAwake
    void Event1 ()
    {
        DialogueManager.ScriptLines(0);
        DialogueManager.EndOnLine = 2;
        lastEvent = 1;
    }
    //OnMouseMove
    void Event2()
    {
        DialogueManager.ScriptLines(2);
        DialogueManager.EndOnLine = 4;
        lastEvent = 2;
    }
    //ONFAIL
    void Event2Fail()
    {
        DialogueManager.ScriptLines(5);
        DialogueManager.EndOnLine = 7;
        lastEvent = 2;
    }
    //CONTINUED
    void Event3()
    {
        DialogueManager.ScriptLines(7);
        DialogueManager.EndOnLine = 9;
        lastEvent = 3;
    }
    //Combat
    void Event4()
    {
        lastEvent = 4;
        DialogueManager.ScriptLines(10);
        DialogueManager.EndOnLine = 11;
    }
    //ONFAIL
    void Event4Fail()
    {
        for (int i = 0; i < ActivateOnCombat.Length; i++)
        {
            ActivateOnCombat[i].SetActive(false);
        }
        EnemySpawner.spawnEnemies = false;
        EnemySpawner.enemiesSpawned = 0;
        for (int i = 0; i < EnemySpawner.transform.childCount; i++)
        {
            Destroy(EnemySpawner.transform.GetChild(i).gameObject);
        }
        DialogueManager.ScriptLines(12);
        DialogueManager.EndOnLine = 13;
        startEvent = 4;
        lastEvent = 40;
        DontDestroyOnLoad(this.gameObject);
    }
    //Success
    void Event5()
    {
        for (int i = 0; i < ActivateOnCombat.Length; i++)
        {
            ActivateOnCombat[i].SetActive(false);
        }
        DialogueManager.ScriptLines(14);
        DialogueManager.EndOnLine = 19;
        lastEvent = 5;
        EnemySpawner.spawnEnemies = false;
    }
    //DEATH
    void Event6()
    {
        for (int i = 0; i < ActivateOnCombat.Length; i++)
        {
            ActivateOnCombat[i].SetActive(false);
        }
        EnemySpawner.spawnEnemies = false;
        EnemySpawner.enemiesSpawned = 0;
        for (int i = 0; i < EnemySpawner.transform.childCount; i++)
        {
            Destroy(EnemySpawner.transform.GetChild(i).gameObject);
        }
        DialogueManager.ScriptLines(20);
        DialogueManager.EndOnLine = 20;
        lastEvent = 6;
    }
}
