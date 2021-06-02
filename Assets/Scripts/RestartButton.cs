using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UltimateCart {
    public class RestartButton : MonoBehaviour {
        private void Awake() {
            GetComponent<Button>().onClick.AddListener(() => RestartLevel());
        }

        private void RestartLevel() {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
