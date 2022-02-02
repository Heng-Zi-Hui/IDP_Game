using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> name;
    private Queue<string> sentences;

    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        name = new Queue<string>();
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        foreach (string sentence in dialogue.name)
        {
            name.Enqueue(sentence);
        }

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            SceneManager.LoadScene("End Game");
            return;
        }

        string sentence = sentences.Dequeue();
        string charaName = name.Dequeue();
        nameText.text = charaName;
        dialogueText.text = sentence;

        if(sentences.Count == 6)
        {
            nannyAppearance();
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }

    public void nannyAppearance()
    {
        enemy.GetComponent<Enemy_LastScene>().appearAndMove();
    }
}
