using System;
using UltimateCart;
using UnityEngine;

namespace UltimateCart {
    public class FinishLine : MonoBehaviour {
        private GameManager _gameManager;

        private void Awake() {
            _gameManager = FindObjectOfType<GameManager>();
        }

        private void OnTriggerEnter(Collider coll) {
            if (coll.attachedRigidbody.gameObject.CompareTag("Car")) {
                Debug.Log("Finished!");
                var lastLevelIndex = PlayerPrefs.GetInt("LevelIndex", 1);
                if (lastLevelIndex < _gameManager.levelIndex) {
                    PlayerPrefs.SetInt("LevelIndex", lastLevelIndex);
                }
                _gameManager.FinishGame(true);
            }
        }
    }
}
