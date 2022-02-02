using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_LastScene : MonoBehaviour
{
    
    public GameObject enemy;
    public GameObject patrolPoint;
    NavMeshAgent agent;

    void Start()
    {
        
    }

    public void appearAndMove(){

        agent = GetComponent<NavMeshAgent>();

        enemy.SetActive(true);

        Transform point = patrolPoint.transform;
        agent.SetDestination(point.position);

        

    }

    void Update(){
        Transform point = patrolPoint.transform;
        float distance1 = Vector3.Distance(point.position, transform.position);
         if(distance1<=0.15){
            gameObject.GetComponent<AudioSource>().Pause();
        }
    }

}
