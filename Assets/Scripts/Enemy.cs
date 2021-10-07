using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Transform objective;

    public int lifePoint = 20;
    public int maxLifePoint = 20;
    public HealthBar sliderHealthBar; 

    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.destination = objective.position;
        sliderHealthBar.SetMaxHealth(maxLifePoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damaged(int prmDamage)
    {
        lifePoint -= prmDamage;
        sliderHealthBar.SetHealth(lifePoint);
        if(lifePoint <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
