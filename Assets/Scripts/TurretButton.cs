using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretButton : MonoBehaviour
{
    public Turret _turret;


    public void SpawnTurret()
    {
        if (GameManager.instance.BuyTurret())
        {
            Instantiate(_turret, transform.position + new Vector3(0, -0.5f, 0), transform.rotation);
            Destroy(gameObject);
        }
    }
}