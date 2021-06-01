using UltimateCart;
using UnityEngine;

namespace UltimateCart {
    public class NextLevelSceneNameFetcher : MonoBehaviour {
        public int levelCount = 3;

        private int _nextLevelIndex;

        private void Awake() {
            _nextLevelIndex = PlayerPrefs.GetInt(GameManager.levelIndexStr, 1);
            if (_nextLevelIndex > levelCount) {
                _nextLevelIndex = Random.Range(1, levelCount + 1);
            }
            GetComponent<ButtonSceneLoader>().sceneName = GameManager.levelScenesPrefix + _nextLevelIndex;
        }
    }
}
