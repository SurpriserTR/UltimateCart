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
            str += min + ":";
        }
        str += sec;
        text.text = str;
    }
}
