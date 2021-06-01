using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeHud : MonoBehaviour {
    public Text text;

    public void UpdateTimer(float remainingTime) {
        var min = (int)remainingTime / 60;
        var sec = (int)remainingTime % 60;
        var str = "";
        if (min > 0) {
            if (min < 10) str += 0;
            str += min + ":";
        }
        if (sec < 10) str += 0;
        str += sec;
        text.text = str;
    }
}
