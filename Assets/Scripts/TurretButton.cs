using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretButton : MonoBehaviour
{
    public Turret _turret;
    public GameObject summonParticle;
    public GameObject summonParticle2;


    public void SpawnTurret()
    {
        if (GameManager.instance.BuyTurret())
        {
            
            Instantiate(summonParticle, transform.position + new Vector3(0, -0.5f, 0), Quaternion.Euler(new Vector3(-90, 0,0)));
            Instantiate(summonParticle2, transform.position + new Vector3(0, -0.5f, 0), Quaternion.Euler(new Vector3(-90, 0,0)));
            Instantiate(_turret, transform.position + new Vector3(0, -0.5f, 0), transform.rotation);
            Destroy(gameObject);
        }
    }
}