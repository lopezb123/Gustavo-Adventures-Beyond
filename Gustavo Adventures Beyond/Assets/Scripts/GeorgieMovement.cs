using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GeorgieMovement : MonoBehaviour
{
   public GameObject[] goal;
    NavMeshAgent agent;
    private int num;
    private int tempNum;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        num = Random.Range(0,goal.Length);
        tempNum = num;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.SetDestination(goal[num].transform.position);
        Debug.Log("goal is " + goal[num].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.isStopped){
            animator.ResetTrigger("isWalking");
            animator.SetTrigger("isIdle");
        }
        else{
            animator.ResetTrigger("isIdle");
            animator.SetTrigger("isWalking");
        }
        if(agent.remainingDistance < agent.stoppingDistance + 2){
            while(tempNum == num){
                tempNum = Random.Range(0,goal.Length);
            }
            num = tempNum;
            agent.SetDestination(goal[num].transform.position);
            Debug.Log("changed goal to " + goal[num].transform.position);
        }
    }
}
