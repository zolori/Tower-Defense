using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Level_One;
    public GameObject Level_Two;
    public GameObject Play;
    public GameObject Quit;
    public GameObject Back;

    // Start is called before the first frame update
    void Start()
    {

        Level_One.SetActive(false);
        
        Level_Two.SetActive(false);
        
        Back.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LoadLvl(int prmLvlNumber)
    {
        GameManager.instance.loadLevel(prmLvlNumber);
    }

    public void OnPlayClick()
    {
        
        Level_One.SetActive(true);
        if (GameManager.instance.lastCompletedLevel == 2)
        {
            Level_Two.SetActive(true);
        }
        
        Back.SetActive(true);
        Play.SetActive(false);
        Quit.SetActive(false);
        
    }

    public void OnQuitClick()
    {
        
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
        
    }

    public void OnBackClick()
    {
        Level_One.SetActive(false);
        Level_Two.SetActive(false);
        Back.SetActive(false);
        Play.SetActive(true);
        Quit.SetActive(true);
        
        
    }
}