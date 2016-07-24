using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class memoriesManager : MonoBehaviour {

    [SerializeField]
    string loadingScene;

    // levelScene[4] == Scene final donde se ve recuerdos tomados
    [SerializeField]
    string[] levelScene = new string[5];

    [SerializeField]
    int level = 0;

    int[] chosenMemories = new int[4];
	// Use this for initialization

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void elegirRecuerdo(int noRecuerdo) {
        if (level < 5)
        {
            chosenMemories[level] = noRecuerdo;
            level++;
            SceneManager.LoadScene(loadingScene);
        }
    }

	void elegirRecuerdo(int noRecuerdo) {
		if (level < 5) 
		{
			chosenMemories [level] = noRecuerdo;
			level++;
			SceneManager.LoadScene (loadingScene);
		}
	}

    public string sceneToLoad() {
        return levelScene[level];
    }
}
