using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    // public float lookRadius = 10f;
    // // initiate lookSpan
    // [Range(0,360)]
    // public float lookAngle = 40f;

    // Transform target;
    // public LayerMask obstructionMask;
    // NavMeshAgent agent;

    // // Start is called before the first frame update
    // void Start()
    // {

    //     target = PlayerManager.instance.player.transform;
    //     //obstruction = ObjectsManager.instance.obstruction1.transform;
    //     agent = GetComponent<NavMeshAgent>();

    //     // patrol around room
        
    // }

    // // Update is called once per frame
    // void Update()
    // {

    //     float distance = Vector3.Distance(target.position, transform.position);
    //     // if player is within look radius
    //     if(distance <= lookRadius){

    //         // if player is within eyes view span
    //         Vector3 direction = (target.position - transform.position).normalized;
    //         if(Vector3.Angle(transform.forward, direction) < lookAngle/2){

    //             if(!Physics.Raycast(transform.position, direction, distance, obstructionMask) || distance < 0.2f){

    //                 agent.SetDestination(target.position);

    //                 if(distance <= agent.stoppingDistance){
    //                     FaceTargetAndChase();
    //                 }

    //             }

    //         }

            
    //     }
        
    // }

    

    // void OnDrawGizmosSelected(){

    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(transform.position, lookRadius);

    // }

    public float radius;
    [Range(0,360)]
    public float angle;
    public GameObject playerRef;

    public GameObject growlAudio;
    public GameObject capturedAudio;
    public LayerMask targetMask;
    public LayerMask obstructionMask;
    NavMeshAgent agent;

    public bool canSeePlayer;

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();

        StartCoroutine(FOVRoutine());
    }

    // void Update(){

    //     //patrol
    //     Transform point1 = patrolPoint1.transform;
    //     agent.SetDestination(point1.position);

    //     Transform point2 = patrolPoint2.transform;
    //     agent.SetDestination(point2.position);

    // }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;

            if (FieldOfViewCheck()){
                // Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);
                // Transform target = rangeChecks[0].transform;

                this.GetComponent<EnemyPatrol_Classroom>().enabled = false;//disable patrol script
                GetComponent<AudioSource>().mute = true;
                growlAudio.GetComponent<AudioSource>().mute = false;//enable growl sound

                Transform target = playerRef.transform;
                FaceTargetAndChase(target);
                //break;
            } else {
                Start();
                break;
            }
        }
    }

    private bool FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                //RaycastHit hit;
                //!Physics.SphereCast(transform.position, radius, transform.forward, out hit, 10)
                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    canSeePlayer = true;
                else
                    canSeePlayer = false;
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer){
            canSeePlayer = false;
        }

        return canSeePlayer;
            
    }

    public void FaceTargetAndChase(Transform target){

        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

        // WaitForSeconds wait = new WaitForSeconds(1.5f);

        //while(true){
            //yield return wait;

            float distance = Vector3.Distance(target.position, transform.position);
        if(distance<=0.50){

            growlAudio.GetComponent<AudioSource>().mute = true;//disable growl sound
            capturedAudio.GetComponent<AudioSource>().mute = false;//enable captured sound
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
            //yield return new WaitForSeconds(1);
        } else {
            agent.SetDestination(target.position);
        }
            
        //}
        

        

        // float distance = Vector3.Distance(target.position, transform.position);
        // while(distance>=0.2f){
        //     agent.SetDestination(target.position);
        //     if(distance<0.2f){
        //         //go back to checkpoint (reload scene)
        //     }
        // }
    }

}
