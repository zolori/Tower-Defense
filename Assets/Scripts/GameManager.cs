using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int lastCompletedLevel;

    public int playerLife = 10;
    private const int PlayerMaxLife = 10;
    public int playerMoney = 90;
    private int playerInitMoney = 90;
    private int MobDrop = 10;
    public int TurretBuy = 50;
    public int TurretRefund = 30;
    public int TurretRefundUpgrade = 70;
    public int turretUpgrade = 100;

    public int levelHeight;

    public bool IsOpen;

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

        CheckLevelHeight();
        
    }

    public void CheckLevelHeight()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            levelHeight = 3;
        }
        else
        {
            levelHeight = 10;
        }
    }

    public void loadLevel(int prmNum)
    {
        reloadValues();
        SceneManager.LoadScene("Scenes/Scene_lvl_" + prmNum);
    }

    public void loadMenu()
    {
        reloadValues();
        SceneManager.LoadScene("Scenes/MainMenu");
    }

    public void Reload()
    {
        reloadValues();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void reloadValues()
    {
        playerLife = PlayerMaxLife;
        playerMoney = playerInitMoney;
    }

    public void AddMoney()
    {
        playerMoney += MobDrop;
        //Debug.Log("+10");
    }

    public Boolean BuyTurret()
    {
        if (playerMoney >= TurretBuy)
        {
            playerMoney -= TurretBuy;
            return true;
        }

        return false;
    }

    public void LastCompletedLevel(int prmLevelId)
    {
        lastCompletedLevel = prmLevelId;
    }
}