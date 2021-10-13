using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // public Scene Level_One;
    // public Scene Level_Two;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadLvl1()
    {
        SceneManager.LoadScene("Scenes/Scene_lvl_1");
    }
    public void loadLvl2()
    {
        
        SceneManager.LoadScene("Scenes/Scene_lvl_2");
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }
    
}
