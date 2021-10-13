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
        GameManager.instance.loadLvl1();
    }
    public void loadLvl2()
    {
        
        GameManager.instance.loadLvl2();
    }
}
