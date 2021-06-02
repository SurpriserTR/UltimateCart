using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UltimateCart {
    public class PauseHomeButton : MonoBehaviour {
        private void Awake() {
            GetComponent<Button>().onClick.AddListener(() => LoadMainMenu());
        }

        private void LoadMainMenu() {
            Time.timeScale = 1;
            SceneManager.LoadScene("Main Menu");
        }
    }
}
