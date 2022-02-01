using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    public GameObject door;
    
    void OnTriggerEnter(Collider other){

        //if(other.CompareTag("Player")){
            door.transform.rotation = Quaternion.Euler(0,3.55f,0);
        //}

    }
    
}
