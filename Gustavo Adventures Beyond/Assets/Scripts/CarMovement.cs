using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarMovement : MonoBehaviour
{

    public GameObject[] goal;
    NavMeshAgent agent;
    private int num;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(goal[num].transform.position);
        Debug.Log("goal is " + goal[num].transform.position);
        num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance < agent.stoppingDistance + 2){
            if(num != goal.Length - 1){
                num ++;
            }
            else{
                num = 0;
            }
            agent.SetDestination(goal[num].transform.position);
            Debug.Log("goal is " + goal[num].transform.position);
        }
    }
}
