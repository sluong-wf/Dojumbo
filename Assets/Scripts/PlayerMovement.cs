using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerDirection {
    Up,
    Down,
    Left,
    Right
}


public enum PlayerState {
    walk,
    attack,
    interact,
    idle
}

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 3f;

    public VectorValue startPosition;

    private Rigidbody2D rb;
    private Animator anim;

    private Vector2 movement;

    public PlayerState currentState;
    public FloatValue playerGold;
    public SignalSender playerGoldSignal;

    void Start() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        transform.position = startPosition.InitialValue;
        
        currentState = PlayerState.idle;

        switch (startPosition.Facing) {
            case PlayerDirection.Down:
                anim.SetFloat("Vertical",-1);
                break;
            case PlayerDirection.Up:
                anim.SetFloat("Vertical",1);
                break;
            case PlayerDirection.Left:
                anim.SetFloat("Horizontal",-1);
                break;
            case PlayerDirection.Right:
                anim.SetFloat("Horizontal",1);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Handle input

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        if (currentState == PlayerState.idle) {
            if (movement != Vector2.zero) {
                anim.SetFloat("Horizontal", movement.x);
                anim.SetFloat("Vertical", movement.y);

                if(movement.x > 0) {
                    startPosition.Facing = PlayerDirection.Right;
                } else if (movement.x < 0) {
                    startPosition.Facing = PlayerDirection.Left;
                } else if (movement.y > 0) {
                    startPosition.Facing = PlayerDirection.Up;
                } else if (movement.y < 0) {
                    startPosition.Facing = PlayerDirection.Down;
                }
            }
            anim.SetFloat("Speed", movement.sqrMagnitude);

            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        } else {
            anim.SetFloat("Speed", 0);
        }


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
        // rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
