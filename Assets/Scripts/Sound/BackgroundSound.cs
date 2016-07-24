using UnityEngine;
using System.Collections;

public class BackgroundSound : MonoBehaviour {
    AudioSource fxSound; 
    [SerializeField]
    AudioClip backMusic; 
    void Start()
    {
        fxSound = GetComponent<AudioSource>();
        fxSound.clip = backMusic;
        fxSound.Play();
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

}
