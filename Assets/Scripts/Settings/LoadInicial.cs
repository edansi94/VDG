using UnityEngine;
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
            SceneManager.LoadScene(loadingScene);
        }
	}
}
