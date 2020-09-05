using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : DialogueBaseClass {

    public Text textHolder;
    public string input;
    [SerializeField] private float delay = 0.1f;
    
    
    void Start() {
    }

    void OnEnable() {
        StartCoroutine(WriteText(input, textHolder, delay));
    }

    public void DisplayFull() {
        StopAllCoroutines();
        WriteFull(input, textHolder);
    }
}
