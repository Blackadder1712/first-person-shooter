using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enemyAI : MonoBehaviour
{

    [SerializeField] Transform target;//player reference 

    NavMeshAgent navMeshAgent; //target AI

    void Start()
    {
       navMeshAgent = GetComponent<NavMeshAgent>();//get AI
    }

    
    void Update()
    {
        navMeshAgent.SetDestination(target.position);//chase player
    }
}
