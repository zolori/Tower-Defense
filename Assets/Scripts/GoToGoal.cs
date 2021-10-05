using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToGoal : MonoBehaviour
{
    public Transform end;

    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.destination = end.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
