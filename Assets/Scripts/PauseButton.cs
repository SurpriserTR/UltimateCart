using System;
using UnityEngine;
using UnityEngine.UI;

namespace UltimateCart {
    public class PauseButton : MonoBehaviour {
        public GameObject pauseMenu;

        private bool _isPaused;

        private void Awake() {
            GetComponent<Button>().onClick.AddListener(() => TogglePause());
        }

        private void TogglePause() {
            if (_isPaused) {
                Time.timeScale = 1;
            }
            else {
                Time.timeScale = 0;
            }
            _isPaused = !_isPaused;
            pauseMenu.SetActive(_isPaused);
        }
    }
}
