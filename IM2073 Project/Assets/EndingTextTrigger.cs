using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTextTrigger : MonoBehaviour
{
    public GameObject uiObject;
    public GameObject dialogueObject;

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
            uiObject.SetActive(true);
            dialogueObject.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(3);
        Destroy(uiObject);
        Destroy(dialogueObject);
        Destroy(gameObject);
    }
}
