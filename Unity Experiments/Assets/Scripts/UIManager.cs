using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    [SerializeField] private Button _startGameButton;   // start button reference
    [SerializeField] private GameObject _startCanvas;    // start game canvas
    [SerializeField] private Button _retryGameButton;   // retry button reference
    [SerializeField] private GameObject _gameOverCanvas;    // game over canvas

    public static GameObject GameOverCanvas;

    private void Start() {
        GameOverCanvas = _gameOverCanvas;

        _startCanvas.SetActive(true);   // enable the start game canvas
        _gameOverCanvas.SetActive(false);   // disable the game over canvas

        _startGameButton.onClick.AddListener(ClickedStartButton);
        _retryGameButton.onClick.AddListener(ClickedRetryButton);
    }

    private void ClickedStartButton() {
        GameManager.StartGame();
        _startCanvas.SetActive(false);
    }

    private void ClickedRetryButton() {
        GameManager.RetryGame();
        _gameOverCanvas.SetActive(false);
    }

}