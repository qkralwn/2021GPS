using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour {
    public static BGM instance = null;

    private AudioSource audioSource;

    public AudioClip background;

    private void Awake() {
        //Screen.SetResolution(1920, 1080, true);

        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = background;

        audioSource.volume = 0.3f;
        audioSource.pitch = 1.4f;
        audioSource.loop = true;
        audioSource.mute = false;

        audioSource.Play();
    }

    // Update is called once per frame
    void Update() {

    }
}