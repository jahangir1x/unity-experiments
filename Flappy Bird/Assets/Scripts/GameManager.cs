using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    [SerializeField] private TMPro.TextMeshProUGUI _scoreTextMesh;         // store score UI text mesh reference

    public static TMPro.TextMeshProUGUI ScoreTextMesh;   // score UI text mesh reference as static field

    // Layers
    public static int PlayerLayer;      // store player layer id
    public static int ObstacleLayer;    // store obstacle layer id

    private void Start() {
        PlayerLayer = LayerMask.NameToLayer("Player");
        ObstacleLayer = LayerMask.NameToLayer("Obstacle");
        ScoreTextMesh = _scoreTextMesh;
    }

    // Game over functionality
    public static void GameOver() {
        Debug.Log("Game over");
    }
}
