using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTextTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject uiObject;
    public GameObject dialogueObject;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    // Start is called before the first frame update
    void Start()
    {
        uiObject.SetActive(false);
        dialogueObject.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider player) //triggered when player collides with the gameObject
    {
        if (player.gameObject.tag == "Player")
        {
            TriggerDialogue(); //Display dialogue
            uiObject.SetActive(true); //show dialogue box
            dialogueObject.SetActive(true); //show dialogues
            StartCoroutine("WaitForSec"); //count down
        }
    }
    
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(1); //count down
        //Destroy(uiObject);
        //Destroy(dialogueObject);
        Destroy(gameObject); //destroys the gameObject
    }
}
