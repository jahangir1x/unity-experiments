using UnityEngine;

public class GameManager : MonoBehaviour {
    public static int ObstacleLayer;    // store obstacle layer id

    private void Start() {
        ObstacleLayer = LayerMask.NameToLayer("Obstacle");
    }

    // Game over functionality
    public static void GameOver() {
        Debug.Log("Game over");
    }
}
