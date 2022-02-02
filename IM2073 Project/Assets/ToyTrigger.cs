using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject toySqueak;
    public GameObject crySound;
    public GameObject crySound1;
    public GameObject crySound2;
    public GameObject enemy;
    
    void OnTriggerEnter(Collider other){

        if(other.CompareTag("Player")){
            
            toySqueak.GetComponent<AudioSource>().Play();
            StartCoroutine(Coroutine());
        }

    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(2);
        // babies cry
        crySound.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);
        crySound1.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);
        crySound2.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(2);
        // enemy walks to beds
        enemy.GetComponent<EnemyPatrol_Classroom>().enabled = false;
        //if (enemy.GetComponent<EnemyPatrol_BabyRoom>().enabled){
            enemy.GetComponent<EnemyPatrol_BabyRoom>().enabled = true;
            enemy.GetComponent<EnemyPatrol_BabyRoom>().Init();
        //} else {
        //    enemy.GetComponent<EnemyPatrol_BabyRoom>().enabled = true;
        //}
    }
        

    // Update is called once per frame
    void Update()
    {
        
    }
}
