using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadFinal : MonoBehaviour {

    [SerializeField]
    string sceneInicial = "Inicio";

    int[] memorias;

    [SerializeField]
    Sprite[] level0;
    [SerializeField]
    Sprite[] level1;
    [SerializeField]
    Sprite[] level2;
    [SerializeField]
    Sprite[] level3;

    [SerializeField]
    SpriteRenderer[] marco =  new SpriteRenderer[4];
    // Use this for initialization
    void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Final"))
        {
            memorias = GameObject.Find("MemoriesManager").GetComponent<memoriesManager>().memoriasEscogidas();
            marco[0].sprite = level0[memorias[0]];
            marco[1].sprite = level1[memorias[1]];
            marco[2].sprite = level2[memorias[2]];
            marco[3].sprite = level3[memorias[3]];
        }
        
    }

    void Update() {
        if (Input.GetButtonDown("Submit"))
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Creditos"))
            {
                Destroy(GameObject.Find("MemoriesManager"));
                Destroy(GameObject.Find("BackgroundSound"));
                SceneManager.LoadScene(sceneInicial);
            }
            else
            {
                SceneManager.LoadScene("Creditos");
            }
        }
    }

}
