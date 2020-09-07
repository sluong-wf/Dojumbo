using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : Interactable
{
    public GameObject dialogueBox;
    public Dialogue dialogueText;

    [TextArea(3, 10)]
    public string[] sentences;

    
    // Update is called once per frame
    void Update()
    {
        if(!dialogueBox.activeInHierarchy) {
            if(Input.GetKeyDown(KeyCode.Space) && playerInRange) {
                dialogueBox.SetActive(true);
                dialogueText.sentences = sentences;
                EnableInactive();
            } else {
                DisableInactive();
            }
        }
    }

    public override void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            base.OnTriggerExit2D(other);
            dialogueBox.SetActive(false);
        }
    }
}
