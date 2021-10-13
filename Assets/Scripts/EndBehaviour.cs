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
    public const int MobDrop = 10;
    public const int TurretBuy = 50;
    public const int TurretUpgrade = 100;
    public TMP_Text moneyText;
    public TMP_Text waveText;
    public spawner spawner;
    public TMP_Text winScreen;
    public TMP_Text loseScreen;
    public TMP_Text lifeText;
    public GameObject TryAgainButton;
    public GameObject MenuButton;
    public GameObject MenuButtonWin;
    public short levelId = 1;

    private void Start()
    {
        UpdateText();

        winScreen.enabled = false;
        loseScreen.enabled = false;
        TryAgainButton.SetActive(false);
        MenuButton.SetActive(false);
        MenuButtonWin.SetActive(false);
        
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
            MenuButtonWin.SetActive(true);
            GameManager.instance.CompletedLvl(levelId);
        }
    }

    public static void AddMoney()
    {
        playerMoney += MobDrop;
        Debug.Log("+10");
    }

    public static Boolean BuyTurret()
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

    public static Boolean UpgradeTurret()
    {
        if (playerMoney >= TurretUpgrade)
        {
            playerLife -= TurretUpgrade;
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
                TryAgainButton.SetActive(true);
                MenuButton.SetActive(true);
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
        lifeText.SetText("Life : " + playerLife);
        
        
        
    }
}
