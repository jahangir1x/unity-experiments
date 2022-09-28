using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [SerializeField] private TMPro.TextMeshProUGUI _scoreTextMesh;         // store score UI text mesh reference

    public static TMPro.TextMeshProUGUI ScoreTextMesh;   // static text mesh reference

    // Layers
    public static int PlayerLayer;      // store player layer id
    public static int ObstacleLayer;    // store obstacle layer id

    private void Start() {
        PlayerLayer = LayerMask.NameToLayer("Player");
        ObstacleLayer = LayerMask.NameToLayer("Obstacle");
        ScoreTextMesh = _scoreTextMesh;

        // Pause all functionality untill player starts the game
        Time.timeScale = 0f;
    }

    public static void StartGame() {
        Time.timeScale = 1f;
    }

    // Game over functionality
    public static void GameOver() {
        Time.timeScale = 0f;
        UIManager.GameOverCanvas.SetActive(true);
    }

    internal static void RetryGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
