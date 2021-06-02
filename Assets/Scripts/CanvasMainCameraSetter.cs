using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyNamespace {
    public class CanvasMainCameraSetter : MonoBehaviour {
        private void Awake() {
            GetComponent<Canvas>().worldCamera = Camera.main;
        }
    }
}
