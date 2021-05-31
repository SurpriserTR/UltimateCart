using System;
using UnityEngine;
using TMPro;

namespace UltimateCart {
    public class TimerHUDManager : MonoBehaviour {
        public TextMeshProUGUI timerText;

        public void SetTime(int remainingSecond) {
            timerText.text = string.Format("{0}:{1:00}", remainingSecond / 60, remainingSecond % 60);
        }
    }
}
