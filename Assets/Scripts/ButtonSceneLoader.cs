using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UltimateCart {
    public class ButtonSceneLoader : MonoBehaviour {
        public string sceneName;

        private void Awake() {
            GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(sceneName));
        }
    }
}
