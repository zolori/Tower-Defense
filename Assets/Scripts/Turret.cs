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
    


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTargetPos", 0f, 0.5f);
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

    void UpdateTargetPos()
    {
        //GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);  // stocke les tags des cibles
        //GameObject nearestEnemy = null;    // ennemi qui sera ciblé
        //float shortestDistance = Mathf.Infinity;    // initialise la distance la plu courte à "infini"

        //foreach(GameObject enemy in enemies)   // boucle sur toutes les cibles
        //{
        //    float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);    // calcule la distance entre la tourelle et la cible

        //    if (distanceToEnemy < shortestDistance) // si la nouvelle distance calculée est plus courte
        //        shortestDistance = distanceToEnemy; // on remplace la distance la plus courte par la nouvelle valeur
        //        nearestEnemy = enemy; // on initialise 
        //}

        //if(nearestEnemy != null && shortestDistance <= range)
        //{
        //    target = nearestEnemy.transform;
        //    fireBullet();
            
        //}
    }

    public void fireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletOrigin.position, bulletPrefab.transform.rotation);
        bullet.GetComponent<bulletBehaviour>().Target = target;
    }
}
