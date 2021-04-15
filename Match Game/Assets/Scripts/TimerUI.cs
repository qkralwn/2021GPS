using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerUI : MonoBehaviour
{
    public float LimitTime;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        LimitTime -= Time.deltaTime;
        text.text = (Mathf.Round(LimitTime) + "'s");

        if(LimitTime < 0) {
            SceneManager.LoadScene("ResultScene");
        }
    }
}
