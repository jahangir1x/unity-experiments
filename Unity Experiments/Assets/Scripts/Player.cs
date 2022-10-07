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
        if (Input.GetMouseButtonDown(0)) {  // if left mouse is pressed
            Jump();                         //    then jump.
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.layer == GameManager.ObstacleLayer) {  // if player collided with obstacle then show Game over message.
            GameManager.GameOver();
        }
    }
}
