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
    public GameObject particules;

    public GameObject upgradeHud;
    public GameObject upgradeButton;
    public GameObject buttonTurret;
    public Turret upgradeTurret;


    // Start is called before the first frame update
    void Start()
    {
        upgradeHud.SetActive(false);
        if (gameObject.CompareTag("TurretLvl2"))
        {
            upgradeButton.SetActive(false);
        }
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

        Instantiate(particules, bulletOrigin.position, bulletPrefab.transform.rotation);
    }

    public void destroyBullet()
    {
        Destroy(bullet);
    }

    public void UpgradeMenuOn()
    {
        Debug.Log("Done");
        upgradeHud.SetActive(true);
        if (gameObject.CompareTag("TurretLvl2"))
        {
            upgradeButton.SetActive(false);
        }

        GameManager.instance.IsOpen = true;
    }

    public void UpgradeMenuOff()
    {
        upgradeHud.SetActive(false);
        GameManager.instance.IsOpen = false;
    }

    public void UpgradeTurret(GameObject prmGameObject)
    {
        Debug.Log("Upgrading");
        if (GameManager.instance.playerMoney >= GameManager.instance.turretUpgrade)
        {
            GameManager.instance.playerMoney -= GameManager.instance.turretUpgrade;
            UTurret(prmGameObject);
        }
    }

    public void UTurret(GameObject prmGameObject)
    {
        Instantiate(upgradeTurret, prmGameObject.transform.position, prmGameObject.transform.rotation);
        UpgradeMenuOff();
        Destroy(prmGameObject);
    }

    public void SellTurret(GameObject prmGameObject)
    {
        Instantiate(buttonTurret, prmGameObject.transform.position - new Vector3(0, -0.5f, 0),
            buttonTurret.transform.rotation);
        GameManager.instance.playerMoney += GameManager.instance.TurretRefund;
        UpgradeMenuOff();
        Destroy(prmGameObject);
    }

    public void Refund()
    {
        if (gameObject.CompareTag("TurretLvl2"))
        {
            GameManager.instance.playerMoney += GameManager.instance.TurretRefundUpgrade;
        }
        else
        {
            GameManager.instance.playerMoney += GameManager.instance.TurretRefund;
        }
    }

    private void OnMouseDown()
    {
        if (GameManager.instance.IsOpen == false)
        {
            UpgradeMenuOn();
        }
    }
}