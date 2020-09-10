using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    // [SerializeField] private Animator anim; 
    
    public GameObject roomTransition;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange) {
            EnableInactive();
            // anim.SetBool("Open", true);
            roomTransition.SetActive(true);
        }
    }

    public override void OnTriggerExit2D(Collider2D other) {
        base.OnTriggerExit2D(other);
        if(other.CompareTag("Player")) {
            // anim.SetBool("Open", false);
            roomTransition.SetActive(false);
        }
    }
}
