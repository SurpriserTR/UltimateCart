using System.Collections;
using System.Collections.Generic;
using UltimateCart;
using UnityEngine;

namespace UltimateCart {
    public class LastLevelSceneNameFetcher : MonoBehaviour
    {
        private void Awake() {
            GetComponent<ButtonSceneLoader>().sceneName = GameManager.levelScenesPrefix + GameManager.CurrentLevelIndex;
        }
    }
}

