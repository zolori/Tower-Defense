using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform objective;

    public int lifePoint = 20;

    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.destination = objective.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void damaged(int prmDamage)
    {
        lifePoint = lifePoint - prmDamage;
        if(lifePoint <= 0)
        {
            
        }
    }

    void die()
    {
        
    }
}
