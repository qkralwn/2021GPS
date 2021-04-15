using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {
    private Text text;
    public int score = 0;

    void Start() {
        text = GetComponent<Text>();
    }

    void Update() {
        text.text = ("SCORE\n" + score);
        //Debug.Log(score);
    }

}