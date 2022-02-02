using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    public GameObject door;
    public GameObject playerRef;
    
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
        yield return new WaitForSeconds(1);
        Enemy enemy = new Enemy();
        //enemy.FaceTargetAndChase(playerRef.transform);
        enemy.angle = 360;
        enemy.radius = 50;
    }
    
}
