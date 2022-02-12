using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    public GameObject door;
    public GameObject playerRef;
    public GameObject enemy;
    
    void OnTriggerEnter(Collider other){

        if(other.CompareTag("Player")){
            door.transform.eulerAngles = new Vector3(0f, 3.55f, 0f);
            door.GetComponent<AudioSource>().Play(); //play openDoor sound
            Destroy(gameObject);
            EnemyChase();
        }

    }

    IEnumerator EnemyChase()
    {
        yield return new WaitForSeconds(0);
        // enemy.GetComponent<Enemy>().angle = 360;
        // enemy.GetComponent<Enemy>().radius = 50;
        enemy.GetComponent<Enemy>().spotted();
    }
    
}
