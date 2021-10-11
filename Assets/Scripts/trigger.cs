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
    }

    // Update is called once per frame
    void Update()
    {
        if (areaTarget == null) // area null verification
        {
            enemiesEntered.Remove(areaTarget);
            if (enemiesEntered.Count != 0)
                areaTarget = enemiesEntered[0];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemiesEntered.Add(other.GetComponent<Enemy>());
            if (enemiesEntered.Count == 1)
            {
                areaTarget = enemiesEntered[enemiesEntered.Count - 1];
                InvokeRepeating("shoot", 0f, 0.5f);
            }
        }
    }

    private void shoot()
    {
        Debug.Log("shoot : " + enemiesEntered.Count);

        if (enemiesEntered.Count != 0)
        {
            if (areaTarget != null)
            {
                turret.target = areaTarget.gameObject.GetComponent<Enemy>();
                turret.fireBullet();
            }
            else
                turret.destroyBullet();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Yolo : " + enemiesEntered.Count);  
        enemiesEntered.Remove(areaTarget);
    }

}
