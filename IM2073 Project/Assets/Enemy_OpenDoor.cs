using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_OpenDoor : MonoBehaviour
{
    // Start is called before the first frame update

    
    void OnTriggerEnter(Collider other){

        if(other.CompareTag("Enemy")){
            gameObject.GetComponent<AudioSource>().Play(); //play openDoor sound
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
