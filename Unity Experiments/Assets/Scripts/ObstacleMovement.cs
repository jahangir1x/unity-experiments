using UnityEngine;

public class ObstacleMovement : MonoBehaviour {
    [SerializeField] private float obstacleMovementSpeed = 1f;

    private void Update() {
        transform.position += Vector3.left * obstacleMovementSpeed * Time.deltaTime;    // move obstacle to the left every frame.
    }
}
