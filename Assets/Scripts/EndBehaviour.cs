using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndBehaviour : MonoBehaviour
{
    public static int playerLife = 10;
    public static int playerMaxLife = 10;
    public static int playerMoney = 90;
    public const int mobDrop = 10;
    public const int turretBuy = 50;
    public const int turretUpgrade = 100;
    public TMP_Text moneyText;
    public TMP_Text waveText;
    public spawner spawner;
    public TMP_Text winScreen;
    public TMP_Text loseScreen;

    private void Start()
    {
        UpdateText();

        winScreen.enabled = false;
        loseScreen.enabled = false;
    }

    void Update()
    {
        UpdateText();
        if (spawner.GetWave() == spawner.GetMaxWave() && GameObject.FindGameObjectWithTag("Enemy")==null)
        {
            //win
            Debug.Log("win");
            winScreen.enabled = true;
            spawner.SetEndGame(true);
        }
    }

    public static void AddMoney()
    {
        playerMoney += mobDrop;
        Debug.Log("+10");
    }

    public static Boolean BuyTurret()
    {
        if (playerMoney >= turretBuy)
        {
            playerMoney -= turretBuy;
            return true;
        }
        else
        {
            return false;
        }
    }

    public static Boolean UpgradeTurret()
    {
        if (playerMoney >= turretUpgrade)
        {
            playerLife -= turretUpgrade;
            return true;
        }
        else
        {
            return false;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.Die();

            if (playerLife <= 0)
            {
                //gameover
                Debug.Log("lose");
                loseScreen.enabled = true;
                spawner.SetEndGame(true);
            }
            else
            {
                playerLife --;
            }
            
        }
    }

    public void UpdateText()
    {
        
        moneyText.SetText("Money : " + playerMoney);    
        waveText.SetText("Wave : " + spawner.GetWave());
    }
}
