using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enemyAI : MonoBehaviour
{

    [SerializeField] Transform target;//player reference 
    [SerializeField] float chaseRange = 5f;//only chase in range

    NavMeshAgent navMeshAgent; //target AI

    float distanceToTarget = Mathf.Infinity; //check player range
    bool isProvoked = false;//if enemy provoked

    void Start()
    {
       navMeshAgent = GetComponent<NavMeshAgent>();//get AI
       
    }

    
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if(isProvoked)
        {
            EngageTarget(); //attack
        }
        else if(distanceToTarget <= chaseRange) //if in range 
        {
         isProvoked =true; 
         
        }
    }

    private void EngageTarget()
    {
        if(distanceToTarget >= navMeshAgent.stoppingDistance) // if not at target
        {
            ChaseTarget();
        }

        if(distanceToTarget <= navMeshAgent.stoppingDistance)//if at target
        {
            AttackTarget();
        }
    }  

    

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);//chase player
    }

    private void AttackTarget()
    {
        Debug.Log("Attacking" +" " + target.name );
    }


    void OnDrawGizmosSelected()//show range
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange); //center and radius
    } 
}
