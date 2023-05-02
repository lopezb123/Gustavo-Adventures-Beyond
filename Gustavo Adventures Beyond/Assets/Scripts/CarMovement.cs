using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class CarMovement : MonoBehaviour
{

    public GameObject[] goal;
    NavMeshAgent agent;
    private int num;
    public GameObject Gustavo;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(goal[num].transform.position);
        Debug.Log("goal is " + goal[num].transform.position);
        num = 0;
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
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

    private void OnTriggerEnter(Collider player){
        Restart();
    }
}
