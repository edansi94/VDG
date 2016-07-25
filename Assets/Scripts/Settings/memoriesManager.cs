using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class memoriesManager : MonoBehaviour {

    [SerializeField]
    public string loadingScene;

    // levelScene[4] == Scene final donde se ve recuerdos tomados
    [SerializeField]
    string[] levelScene = new string[5];

    [SerializeField]
    int level = 0;

    int[] chosenMemories = new int[4];

    [SerializeField]
    Vector3 puntoSpawn0 = Vector3.zero;

    [SerializeField]
    Vector3[] puntosSpawn1 = new Vector3[1];

    [SerializeField]
    Vector3[] puntosSpawn2 = new Vector3[1];

    [SerializeField]
    Vector3[] puntosSpawn3 = new Vector3[1];

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        Cursor.visible = false;
    }

    void Update() {
        if (Input.GetButtonDown("Cancel"))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif

        }
    }

    public void elegirRecuerdo(int noRecuerdo) {
        if (level < 5)
        {
            chosenMemories[level] = noRecuerdo;
            level++;
			float fadeTime = GameObject.Find ("Main Camera").GetComponent<Fading> ().BeginFade (1);
			StartCoroutine (FadeEffect (fadeTime  * 2));
            SceneManager.LoadScene(loadingScene);
        }
    }

	public IEnumerator FadeEffect(float fadeTime)
	{
		yield return new WaitForSeconds (fadeTime);
	}

    public string sceneToLoad() {
        return levelScene[level];
    }

    public int[] memoriasEscogidas() {
        return chosenMemories;
    }

    public Vector3 dondeAparecer() {
        switch (level)
        {
            case 0:
                return puntoSpawn0;
            case 1:
                return puntosSpawn1[chosenMemories[0]];
            case 2:
                return puntosSpawn2[chosenMemories[1]];
            case 3:
                return puntosSpawn3[chosenMemories[2]];
            default:
                return Vector3.zero;
        }
    }
}
