using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private float jumpForce = 1f;
    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Jump() {
        rb.velocity = Vector2.up * jumpForce;
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Jump();
        }
    }
}
