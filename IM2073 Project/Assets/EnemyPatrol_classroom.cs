using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol_Classroom : MonoBehaviour
{

    public GameObject patrolPoint1;
    public GameObject patrolPoint2;
    public GameObject patrolPoint3;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Transform point1 = patrolPoint1.transform;
        agent.SetDestination(point1.position);
    }

    // Update is called once per frame
    void Update()
    {
        Transform point1 = patrolPoint1.transform;
        Transform point2 = patrolPoint2.transform;
        Transform point3 = patrolPoint3.transform;

        float distance1 = Vector3.Distance(point1.position, transform.position);
        float distance2 = Vector3.Distance(point2.position, transform.position);
        float distance3 = Vector3.Distance(point3.position, transform.position);
        if(distance1<=0.15){
            agent.SetDestination(point2.position);
        } else if(distance2<=0.38){
            agent.SetDestination(point3.position);
        } else if(distance3<=0.15){
            agent.SetDestination(point1.position);
        }
        
    }
    
}