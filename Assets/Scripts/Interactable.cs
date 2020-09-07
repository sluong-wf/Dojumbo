using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    private PlayerMovement player;
    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public virtual void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            playerInRange = true;
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            playerInRange = false;
        }
    }


    // render playable character movement inactive
    protected void EnableInactive() {
        player.currentState = PlayerState.interact;
    }

    protected void DisableInactive() {
        player.currentState = PlayerState.idle;
    }
}
