using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    public Dialogue dialogText;
    
    void Start() {
        dialogText.gameObject.SetActive(true);
    }
}
