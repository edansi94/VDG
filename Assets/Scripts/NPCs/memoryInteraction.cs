using UnityEngine;
using System.Collections;

public class memoryInteraction : MonoBehaviour {

	GameObject globalM;
	globalSettings.playerSettings PlayerSettings;

	void Start()
	{
		globalM = GameObject.FindGameObjectWithTag ("MainCamera");
		PlayerSettings = globalM.GetComponent<globalSettings> ().PlayerSettings;
	}
		
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player") {
			PlayerSettings.setMemoryAmount (10);
			print (PlayerSettings.memoryAmount);
			Destroy (this.gameObject);
		}
	}
}
