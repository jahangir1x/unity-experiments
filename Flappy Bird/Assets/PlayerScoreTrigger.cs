
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScoreTrigger : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        IncrementScore();
    }

    private void IncrementScore() {
        var scoreUIText = GameManager.ScoreTextMesh;
        scoreUIText.text = (int.Parse(scoreUIText.text) + 1).ToString();
    }
}
