using System;
using UltimateCart;
using UnityEngine;

public class FinishLine : MonoBehaviour {
    private GameManager _gameManager;

    private void Awake() {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider col) {
        Debug.Log("Finished!");
        var lastLevelIndex = PlayerPrefs.GetInt("LevelIndex", 1);
        if (lastLevelIndex < _gameManager.levelIndex) {
            PlayerPrefs.SetInt("LevelIndex", lastLevelIndex);
        }
        _gameManager.FinishGame(true);
    }
}
