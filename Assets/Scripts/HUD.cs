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

    // Start is called before the first frame update
    void Awake()
    {
        Spawner = GameObject.Find("Spawn");
        spawner = Spawner.GetComponent<spawner>();
    }

    public void Reload()
    {
        GameManager.instance.Reload();
    }

    public void getMenu()
    {
        GameManager.instance.loadMenu();
    }

    public void Ready()
    {
        spawner.IsReady();
    }
}