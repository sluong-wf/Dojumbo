using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    
    public Dialogue dialogText;
    public string[] sentences;
    private int index = 0;
    
    void Start() {
        index = 0;
        // StartCoroutine(dialogueSequence());
        DialogueSequence();
    }

    void OnDisable() {
        index = 0;
    }

    private void DialogueSequence() {
        dialogText.input = sentences[index];
        dialogText.gameObject.SetActive(false);
        dialogText.gameObject.SetActive(true);
    }

    // private IEnumerator dialogueSequence() {
    //     dialogText.gameObject.SetActive(false);
    //     dialogText.gameObject.SetActive(true);
    //     yield return new WaitUntil(() => dialogText.finished);
    // }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            // code here to display full sentence before closing
            if (dialogText.displayedCount < sentences[index].Length) {
                dialogText.DisplayFull();
            }
            else {
                index += 1;
                if (index <= sentences.Length-1) {
                    DialogueSequence();
                } else {
                    this.gameObject.SetActive(false);
                }
            }
        }
    }
}
