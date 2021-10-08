using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBehaviour : MonoBehaviour
{
    public static int playerLife = 10;
    public static int playerMaxLife = 10;
    public static int playerMoney = 90;
    public static int mobDrop = 10;
    public static int turretBuy = 50;
    public static int turretUpgrade = 100;
    

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
            }
            else
            {
                playerLife --;
            }
            
        }
    }
}
