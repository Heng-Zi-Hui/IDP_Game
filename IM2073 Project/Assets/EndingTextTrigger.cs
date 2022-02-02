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
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            TriggerDialogue();
            uiObject.SetActive(true);
            dialogueObject.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }
    
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(1);
        //Destroy(uiObject);
        //Destroy(dialogueObject);
        Destroy(gameObject);
    }
}
