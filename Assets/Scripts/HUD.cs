using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public TMP_Text moneyText;
    public TMP_Text waveText;
    public GameObject Spawner;
    public spawner spawner;
    public TMP_Text winScreen;
    public TMP_Text loseScreen;
    public TMP_Text lifeText;
    public TMP_Text EnemyLeftText;
    public GameObject TryAgainButton;
    public GameObject MenuButton;
    public GameObject MenuButtonWin;
    public AudioSource source;


    // Start is called before the first frame update
    void Awake()
    {
        Spawner = GameObject.Find("Spawn");
        spawner = Spawner.GetComponent<spawner>();
    }

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Reload()
    {
        GameManager.instance.Reload();
        playSound();
    }

    public void getMenu()
    {
        GameManager.instance.loadMenu();
        playSound();
    }

    public void Ready()
    {
        spawner.IsReady();
        playSound();
    }

    public void playSound()
    {
        source.Play();
    }
}