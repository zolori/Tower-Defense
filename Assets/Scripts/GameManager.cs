using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject lvl1Btn;
    public GameObject lvl2Btn;
    public static short lastCompletedLevel;

    // Start is called before the first frame update
    void Start()
    {
        // Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void CompletedLvl(short prmIndex)
    {
        lastCompletedLevel = prmIndex;
    }
}