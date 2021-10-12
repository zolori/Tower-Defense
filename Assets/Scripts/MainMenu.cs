using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Level_One;
    public GameObject Level_Two;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void loadLvl1()
    {
        SceneManager.LoadScene("Scene_Elvyn");
    }
    void loadLvl2()
    {
        //if
        SceneManager.LoadScene("Scene_Alban");
    }
}
