using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject dialogBox;
    public Dialogue dialogText;

    [TextArea(3, 10)]
    public string[] sentences;

    public bool playerInRange;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange) {
            if(!dialogBox.activeInHierarchy) {
                dialogBox.SetActive(true);
                dialogBox.GetComponent<DialogueHolder>().sentences = sentences;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
