using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool playerInRange;
    public bool dialogueStarted;
    public bool playerStopped;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            playerInRange = false;
            FindObjectOfType<DialogueManager>().EndDialogue();
            dialogueStarted = false;
        }
    }

    void Update()
    {
        if (playerInRange)
        {
            if (!dialogueStarted)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    TriggerDialogue();
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    DisplayNextSentence();
                }
            }
        }
    }

    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        dialogueStarted = true;
    }

    public void DisplayNextSentence()
    {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }
}
