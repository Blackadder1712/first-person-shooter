using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enemyAI : MonoBehaviour
{

    [SerializeField] Transform target;//player reference 
    [SerializeField] float chaseRange = 5f;//only chase in range
    [SerializeField] float turnSpeed = 5f;

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

    public void OnDamageTaken()//enemy engages if give damage
    {
        isProvoked = true;
    }

    private void EngageTarget()
    {
        FaceTarget(); //look at player
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
        GetComponent<Animator>().SetBool("attack", false); //activate chase animation, not attack
        GetComponent<Animator>().SetTrigger("move"); //activate chase animation
        navMeshAgent.SetDestination(target.position);//chase player
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true); //activate chase animation
        Debug.Log("Attacking" +" " + target.name );
    }

    private void FaceTarget()//face player while attacking 
    {
        Vector3 direction = (target.position - transform.position).normalized;// player position minus enemy position 
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));//look based on new vector 3 
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed); //rotate time smooth between 2 vectors
    }


    void OnDrawGizmosSelected()//show range
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange); //center and radius
    } 
}
