using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndBehaviour : MonoBehaviour
{
    public GameObject HUD;
    public HUD hud;

    public GameObject OnTriggerEffect;
    public int levelId;
    public AudioSource audioSource;
    public AudioClip winClip;
    public AudioClip loseClip;
    public AudioClip foumClip;

    public bool winSound = true;

    private void Start()
    {
        HUD = GameObject.Find("HUD");
        hud = HUD.GetComponent<HUD>();

        audioSource = GetComponent<AudioSource>();

        levelId = SceneManager.GetActiveScene().buildIndex;
        hud.winScreen.enabled = false;
        hud.loseScreen.enabled = false;
        hud.TryAgainButton.SetActive(false);
        hud.MenuButton.SetActive(false);
        hud.MenuButtonWin.SetActive(false);
    }

    void Update()
    {
        UpdateText();

        if (hud.spawner.GetWave() == hud.spawner.GetMaxWave() && GameObject.FindGameObjectWithTag("Enemy") == null && GameManager.instance.playerLife >= 0)
        {
            //win
            levelId = SceneManager.GetActiveScene().buildIndex;
            GameManager.instance.LastCompletedLevel(levelId);
            hud.winScreen.enabled = true;
            hud.spawner.SetEndGame(true);
            hud.MenuButtonWin.SetActive(true);
			
            GameManager.instance.LastCompletedLevel(levelId);
            if (winSound)
            {
                winSound = false;
                audioSource.clip = winClip;
                audioSource.Play();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            Instantiate(OnTriggerEffect, new Vector3(enemy.transform.position.x, GameManager.instance.levelHeight, enemy.transform.position.z), enemy.transform.rotation);
            enemy.Die();

            if (GameManager.instance.playerLife <= 1)
            {
                //gameover
                Debug.Log("lose");
                if (GameManager.instance.playerLife == 1)
                {
                    GameManager.instance.playerLife--;
                    audioSource.PlayOneShot(loseClip);
                }
                
                hud.loseScreen.enabled = true;
                hud.spawner.SetEndGame(true);
                hud.TryAgainButton.SetActive(true);
                hud.MenuButton.SetActive(true);
                
            }
            else
            {
                GameManager.instance.playerLife--;
                audioSource.PlayOneShot(foumClip);
            }
        }
    }

    void UpdateText()
    {
        hud.moneyText.SetText("Money : " + GameManager.instance.playerMoney);
        hud.waveText.SetText("Wave : " + hud.spawner.GetWave());
        hud.lifeText.SetText("Life : " + GameManager.instance.playerLife);
        hud.EnemyLeftText.SetText("Enemy : " + GameObject.FindGameObjectsWithTag("Enemy").Length);
    }
}