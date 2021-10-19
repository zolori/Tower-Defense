using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject lvl1Btn;
    public GameObject lvl2Btn;
    public static short lastCompletedLevel;

    public Turret upgradeTurret;
    public Turret baseTurret;
    public GameObject buttonTurret;

    public int playerLife = 10;
    private const int PlayerMaxLife = 10;
    public int playerMoney = 90;
    private int playerInitMoney = 90;
    private int MobDrop = 10;
    public int TurretBuy = 50;
    public int TurretRefund = 30;
    public int TurretRefundUpgrade = 70;
    public int turretUpgrade = 100;

    public bool IsOpen = false;

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

    public void CompletedLvl(short prmIndex)
    {
        lastCompletedLevel = prmIndex;
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
        else
        {
            return false;
        }
    }
    
    
}