using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float lookRadius = 10f;
    // initiate lookSpan

    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {

        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(target.position, transform.position);

        // if player is within eyes view span
        // if player is within look radius
        if(distance <= lookRadius){
            agent.SetDestination(target.position);

            if(distance <= agent.stoppingDistance){
                FaceTarget();
            }
        }
        
    }

    void FaceTarget(){

        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quanternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

    }

    void OnDrawGizmosSelected(){

        OnDrawGizmosSelected.color = Color.red;
        OnDrawGizmosSelected.DrawWireSphere(transform.position, lookRadius);

    }
}
