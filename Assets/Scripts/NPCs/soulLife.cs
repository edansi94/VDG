using UnityEngine;
using System.Collections;

public class soulLife : MonoBehaviour {

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
			PlayerSettings.setSoulAmount (10);
			print (PlayerSettings.soulAmount);
			Destroy (this.gameObject);
		}
	}
}
