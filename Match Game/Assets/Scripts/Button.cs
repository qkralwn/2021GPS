using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Back() {
        SceneManager.LoadScene("LobyScene");
    }

    public void Loby() {
        SceneManager.LoadScene("LobyScene");
    }

    public void Play() {
        SceneManager.LoadScene("GameScene");
    }

    public void Replay() {
        SceneManager.LoadScene("GameScene");
    }

    public void Quit() {
        Application.Quit();
    }
}
