using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadInicial : MonoBehaviour {

    [SerializeField]
    string sceneInicial = "Inicio";
    [SerializeField]
    bool reiniciar = false;

    string loadingScene;

    // Use this for initialization
    void Start () {
        loadingScene = GameObject.Find("MemoriesManager").GetComponent<memoriesManager>().loadingScene;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Interact") && !reiniciar)
        {
            float fadeTime = GameObject.Find("Main Camera").GetComponent<Fading>().BeginFade(1);
            StartCoroutine(FadeEffect(fadeTime * 2));
            SceneManager.LoadScene(loadingScene);
        }
        if (Input.GetButtonDown("Submit") && reiniciar)
        {
            Destroy(GameObject.Find("MemoriesManager"));
            Destroy(GameObject.Find("BackgroundSound"));
            SceneManager.LoadScene(sceneInicial);
        }

    }

    public IEnumerator FadeEffect(float fadeTime)
    {
        yield return new WaitForSeconds(fadeTime);
    }
}
