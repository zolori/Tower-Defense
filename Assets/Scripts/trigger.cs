using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public Turret turret;
    Enemy areaTarget;
    List<Enemy> enemiesEntered = new List<Enemy>();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("shoot", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (areaTarget == null)
        {
            if (enemiesEntered.Count != 0)
                areaTarget = enemiesEntered[0];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemiesEntered.Add(other.GetComponent<Enemy>());
        }
    }

    private void shoot()
    {
        while (enemiesEntered.Count != 0)
        {
            areaTarget = enemiesEntered[0];
            if (areaTarget != null)
            {
                turret.target = areaTarget.gameObject.GetComponent<Enemy>();
                turret.fireBullet();
                break;
            }
            else
            {
                enemiesEntered.Remove(enemiesEntered[0]);
                turret.destroyBullet();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("nb dans tableau : " + enemiesEntered.Count);
        enemiesEntered.Remove(other.GetComponent<Enemy>());
        areaTarget = null;
    }
}