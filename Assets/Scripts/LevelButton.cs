using UltimateCart;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour {
    public int levelIndex;
    private void Awake() {
        GetComponent<ButtonSceneLoader>().sceneName = GameManager.levelScenesPrefix + levelIndex;
        var lastLevelIndex = PlayerPrefs.GetInt("LevelIndex", 1);
        if (levelIndex > lastLevelIndex) {
            GetComponent<Button>().interactable = false;
        }
    }
}
