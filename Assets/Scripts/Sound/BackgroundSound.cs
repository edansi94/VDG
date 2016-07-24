using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackgroundSound : MonoBehaviour {
    AudioSource fxSound; 
    [SerializeField]
    AudioClip backMusic;
    [SerializeField]
    AudioClip introMusic;

    void Start()
    {
        fxSound = GetComponent<AudioSource>();
        fxSound.clip = introMusic;
        fxSound.Play();
    }

    void OnLevelWasLoaded(int level)
    {
        if (level != SceneManager.GetSceneByName("Inicio").buildIndex)
        {
            if (fxSound.clip != backMusic)
            {
                fxSound.clip = backMusic;
                fxSound.Play();
            }
        }
        else
        {
            fxSound.clip = introMusic;
            fxSound.Play();
        }
        
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

}
