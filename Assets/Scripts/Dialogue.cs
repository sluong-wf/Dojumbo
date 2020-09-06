using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : DialogueBaseClass {

    public Text textHolder;
    public GameObject dialogueHolder;

    public string[] sentences;
    [SerializeField] private float delay = 0.1f;
    public bool fullFinished;

    private int currIndex;
    
    void Start() {
    }

    void OnEnable() {
        currIndex = 0;
        StartCoroutine(WriteText(sentences[currIndex], textHolder, delay));
    }

    public void DisplayFull() {
        StopAllCoroutines();
        WriteFull(sentences[currIndex], textHolder);
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            // code here to display full sentence before closing
            if (!finished) {
                DisplayFull();
            }
            else {
                currIndex += 1;
                if (currIndex <= sentences.Length-1) {
                    StartCoroutine(WriteText(sentences[currIndex], textHolder, delay));
                } else {
                    dialogueHolder.SetActive(false);
                }
            }
        }
    }
}
