using UnityEngine;
using System.Collections;

public class memoryInteraction : MonoBehaviour {

    [SerializeField]
    int id;

	GameObject globalM;
	globalSettings.playerSettings PlayerSettings;
    memoriesManager manager;

	void Start()
	{
		globalM = GameObject.FindGameObjectWithTag ("MainCamera");
		PlayerSettings = globalM.GetComponent<globalSettings> ().PlayerSettings;
        manager = GameObject.Find("MemoriesManager").GetComponent<memoriesManager>();

    }
		
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player") {
            manager.elegirRecuerdo(id);
            PlayerSettings.setMemoryAmount (10);
			print (PlayerSettings.memoryAmount);
			Destroy (this.gameObject);
		}
	}
}
