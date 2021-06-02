using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UltimateCart {
    public class QuitButton : MonoBehaviour {
        private void Awake() {
            GetComponent<Button>().onClick.AddListener(() => Application.Quit());
        }
    }
}
