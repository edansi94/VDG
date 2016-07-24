using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    memoriesManager manager;
    bool loading = false;
    // Use this for initialization
    void Start () {
        manager = GameObject.Find("MemoriesManager").GetComponent<memoriesManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!loading)
        {
            StartCoroutine(LoadNewScene());
            loading = true;
        }
	}

    IEnumerator LoadNewScene()
    {

        // This line waits for 3 seconds before executing the next line in the coroutine.
        // This line is only necessary for this demo. The scenes are so simple that they load too fast to read the "Loading..." text.
        yield return new WaitForSeconds(3);

        // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
        AsyncOperation async = SceneManager.LoadSceneAsync(manager.sceneToLoad());

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!async.isDone)
        {
            yield return null;
        }
    }

}
