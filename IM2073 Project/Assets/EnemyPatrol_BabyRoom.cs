using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol_BabyRoom : MonoBehaviour
{

    public GameObject patrolPoint1;
    public GameObject enemy;
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
        float distance1 = Vector3.Distance(point1.position, transform.position);

        if(distance1<=0.15){
            enemy.GetComponent<EnemyPatrol_Classroom>().enabled = true;
            this.enabled = false;
        }
        
    }
}
