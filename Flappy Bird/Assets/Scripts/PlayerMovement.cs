using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed = 5f;

    private Rigidbody2D playerRigidBody;
    private Vector2 movement;
    private Vector2 mousePos;

    private void Start() {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");    // horizontal movement input
        movement.y = Input.GetAxisRaw("Vertical");      // vertical movement input

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);     // get world position
    }

    private void FixedUpdate() {
        Vector2 deltaPosition = movement * moveSpeed * Time.fixedDeltaTime;                     // calculate delta position based on input

        playerRigidBody.MovePosition(playerRigidBody.position + deltaPosition);                 // move player
        Camera.main.transform.position += new Vector3(deltaPosition.x, deltaPosition.y, 0);     // move camera with player

        Vector2 lookDirection = mousePos - playerRigidBody.position;    // calculate relative position of mouse
        float lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;  // calculate angle to rotate the player

        playerRigidBody.rotation = lookAngle;                           // rotate the player to mouse

    }
}
