using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKey : MonoBehaviour
{

    public GameObject collectedKey;

    // Start is called before the first frame update
    // void Start()
    // {
    //     gameObject.SetActive(true);
    //     x.SetActive(true);
    // }

    void OnTriggerEnter(Collider other){

        if(other.CompareTag("Player")){
            
            gameObject.GetComponent<AudioSource>().Play(); //play collected sound

            //enable key above kids head
            collectedKey.SetActive(true);

            gameObject.SetActive(false);
            //Destroy(gameObject);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
