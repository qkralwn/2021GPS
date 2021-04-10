using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour {
    private Player player;
    private EnemySpawner spawner;
    private UI_Time timer;

    public GameObject gameOverUI;

    // Start is called before the first frame update
    void Start() {
        timer = FindObjectOfType<UI_Time>();
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<EnemySpawner>();
    }

    // Update is called once per frame
    void Update() {
        if (player.GetHP() <= 0) {
            spawner.OffSpawner();
            timer.OffTimer();

            gameOverUI.SetActive(true);
        }
    }

    public void RestartButton() {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitButton() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}