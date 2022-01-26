using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public float lookRadius = 10f;
    // initiate lookSpan
    [Range(0,360)]
    public float lookAngle = 40f;

    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {

        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();

        // patrol around room
        
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(target.position, transform.position);
        // if player is within look radius
        if(distance <= lookRadius){

            // if player is within eyes view span
            Vector3 direction = (target.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward, direction) < lookAngle/2){

                if(!Physics.Raycast(transform.position, direction, distance) || distance < 0.2f){

                    agent.SetDestination(target.position);

                    if(distance <= agent.stoppingDistance){
                        FaceTarget();
                    }

                }

            }

            
        }
        
    }

    void FaceTarget(){

        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

    }

    void OnDrawGizmosSelected(){

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        //Gizmos.DrawLine(transform.position, Vector3.Angle(transform.forward, direction));

    }
}
