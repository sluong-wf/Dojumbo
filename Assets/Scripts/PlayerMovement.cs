using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState {
    walk,
    attack,
    interact
}

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 3f;

    public Rigidbody2D rb;
    public Animator animator;
    public VectorValue startingPosition;

    Vector2 movement;

    public FloatValue playerGold;
    public SignalSender playerGoldSignal;

    void Start() {
        transform.position = startingPosition.initialValue;
    }

    // Update is called once per frame
    void Update()
    {
        // Handle input

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        if (movement != Vector2.zero) {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }
        animator.SetFloat("Speed", movement.sqrMagnitude);


        // TEST GOLD SYSTEM
        if(Input.GetKeyDown(KeyCode.G)) {
            playerGold.initialValue += 50;
            playerGoldSignal.Raise();
            Debug.Log(playerGold.initialValue);
        }
    }

    void FixedUpdate() 
    {
        // Handle movement

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
