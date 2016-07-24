using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadInicial : MonoBehaviour {

    string loadingScene;

    // Use this for initialization
    void Start () {
        loadingScene = GameObject.Find("MemoriesManager").GetComponent<memoriesManager>().loadingScene;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Interact"))
        {
            float fadeTime = GameObject.Find("Main Camera").GetComponent<Fading>().BeginFade(1);
            StartCoroutine(FadeEffect(fadeTime * 2));
            SceneManager.LoadScene(loadingScene);
        }
	}

    public IEnumerator FadeEffect(float fadeTime)
    {
        yield return new WaitForSeconds(fadeTime);
    }
}
