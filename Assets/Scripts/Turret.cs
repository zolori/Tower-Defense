using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Turret : MonoBehaviour
{
    public Enemy target;
    public float range = 50f;
    public string tag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform bulletOrigin;
    private GameObject bullet;

    private HUD _hud;


    // Start is called before the first frame update
    void Start()
    {
        _hud = GameObject.FindGameObjectWithTag("UI").GetComponent<HUD>();

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) // si pas de cible
            return; // on quitte

        Vector3 direction = target.transform.position - transform.position; // calcule la direction
        Quaternion lookRotation = Quaternion.LookRotation(direction); // calcule la rotation
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    public void fireBullet()
    {
        bullet = Instantiate(bulletPrefab, bulletOrigin.position, bulletPrefab.transform.rotation);
        bullet.GetComponent<bulletBehaviour>().Target = target;
    }

    public void destroyBullet()
    {
        Destroy(bullet);
    }

    public void UpgradeMenu(Turret prmTurret)
    {
        Debug.Log("Done");
        _hud.TurretMenu(prmTurret);
    }
}