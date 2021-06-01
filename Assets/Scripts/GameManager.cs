using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

namespace UltimateCart {
    public class GameManager : MonoBehaviour {

        public static int CurrentLevelIndex;
        public static string levelIndexStr = "LevelIndex";
        public static string levelScenesPrefix = "Level ";
        
        public string winSceneName;
        public string gameOverSceneName;
        public int levelIndex = 0;

        [Header("Level Spesific")] 
        public float time = 20;

        private TimeHud _timeHud;
        private Controls _controls;
        private GameState _gameState = GameState.Waiting;
        
        public void Awake() {
            CurrentLevelIndex = levelIndex;
            _controls = FindObjectOfType<Controls>();
            _timeHud = FindObjectOfType<TimeHud>();
            StartTheGame();
        }

        private void Update() {
            if (_gameState == GameState.Playing) {
                time -= Time.deltaTime;
                _timeHud.UpdateTimer(time);
                if (time <= 0) {
                    FinishGame(false);
                }
            }
        }

        private void StartTheGame() {
            _controls.Enabled = true;
            _gameState = GameState.Playing;
        }

        public void FinishGame(bool success) {
            _controls.Enabled = false;
            _gameState = GameState.End;
            if (success) {
                if (levelIndex + 1 > PlayerPrefs.GetInt(levelIndexStr, 1)) {
                    PlayerPrefs.SetInt(levelIndexStr, levelIndex + 1);
                }
                SceneManager.LoadScene(winSceneName);
            }
            else SceneManager.LoadScene(gameOverSceneName);
        }

        private enum GameState {
            Playing,
            Waiting,
            End
        }
    }
}

