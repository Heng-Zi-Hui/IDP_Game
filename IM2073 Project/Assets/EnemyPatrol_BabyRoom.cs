using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol_BabyRoom : MonoBehaviour
{

    public GameObject patrolPoint1;
    public GameObject patrolPoint2;

    public GameObject crySound;
    public GameObject crySound1;
    public GameObject crySound2;
    public GameObject enemy;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public void Init(){
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
            StartCoroutine(Coroutine());
        }
        
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(2);
        crySound.GetComponent<AudioSource>().Pause();
        crySound1.GetComponent<AudioSource>().Pause();
        crySound2.GetComponent<AudioSource>().Pause();
        yield return new WaitForSeconds(1);

        Transform point2 = patrolPoint2.transform;
        agent.SetDestination(point2.position);
        enemy.GetComponent<EnemyPatrol_Classroom>().enabled = true;


        this.enabled = false;

    }
}
