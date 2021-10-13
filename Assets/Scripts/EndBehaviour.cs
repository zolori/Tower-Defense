using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndBehaviour : MonoBehaviour
{
    public GameObject HUD;
    public HUD hud;

    // private TMP_Text moneyText = hud.moneyText;
    // private TMP_Text waveText = hud.waveText;
    // private spawner spawner = hud.spawner;
    // private TMP_Text winScreen = hud.winScreen;
    // private TMP_Text loseScreen = hud.loseScreen;
    // private TMP_Text lifeText = hud.lifeText;
    // private GameObject TryAgainButton = hud.TryAgainButton;
    // private GameObject MenuButton = hud.MenuButton;
    // private GameObject MenuButtonWin = hud.MenuButtonWin;
    private short levelId = 1;

    private void Start()
    {
        HUD = GameObject.Find("HUD");
        hud = HUD.GetComponent<HUD>();


        hud.winScreen.enabled = false;
        hud.loseScreen.enabled = false;
        hud.TryAgainButton.SetActive(false);
        hud.MenuButton.SetActive(false);
        hud.MenuButtonWin.SetActive(false);
    }

    void Update()
    {
        Debug.Log("fail");
        UpdateText();
        if (hud.spawner.GetWave() == hud.spawner.GetMaxWave() && GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            //win
            Debug.Log("win");
            hud.winScreen.enabled = true;
            hud.spawner.SetEndGame(true);
            hud.MenuButtonWin.SetActive(true);
            GameManager.instance.CompletedLvl(levelId);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.Die();

            if (GameManager.instance.playerLife <= 0)
            {
                //gameover
                Debug.Log("lose");
                hud.loseScreen.enabled = true;
                hud.spawner.SetEndGame(true);
                hud.TryAgainButton.SetActive(true);
                hud.MenuButton.SetActive(true);
            }
            else
            {
                GameManager.instance.playerLife--;
            }
        }
    }

    void UpdateText()
    {
        Debug.Log("fail+");


        hud.moneyText.SetText("Money : " + GameManager.instance.playerMoney);
        hud.waveText.SetText("Wave : " + hud.spawner.GetWave());
        hud.lifeText.SetText("Life : " + GameManager.instance.playerLife);
    }
}