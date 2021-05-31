using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

namespace UltimateCart {
    public class GameManager : MonoBehaviour {
        public string winSceneName;
        public string gameOverSceneName;

        [Header("Level Spesific")] 
        public float time = 20;

        private Controls _controls;
        private GameState _gameState = GameState.Waiting;
        
        public void Awake() {
            _controls = FindObjectOfType<Controls>();
            StartTheGame();
        }

        private void Update() {
            if (_gameState == GameState.Playing) {
                time -= Time.deltaTime;
                if (time <= 0) {
                    FinishGame(false);
                }
            }
        }

        private void StartTheGame() {
            _controls.Enabled = true;
            _gameState = GameState.Playing;
        }

        private void FinishGame(bool success) {
            _controls.Enabled = false;
            _gameState = GameState.End;
            if (success) SceneManager.LoadScene(winSceneName);
            else SceneManager.LoadScene(gameOverSceneName);
        }

        private enum GameState {
            Playing,
            Waiting,
            End
        }
    }
}

