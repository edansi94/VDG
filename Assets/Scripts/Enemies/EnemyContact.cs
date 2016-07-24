using UnityEngine;
using System.Collections;

public class EnemyContact : MonoBehaviour {

	GameObject globalM;
	globalSettings.playerSettings PlayerSettings;
	PlayerHealth health;

	void Start()
	{
		globalM = GameObject.FindGameObjectWithTag ("MainCamera");
		health = globalM.GetComponent<PlayerHealth> ();
		PlayerSettings = globalM.GetComponent<globalSettings> ().PlayerSettings;
	}


	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player") {
			health.TakeDamage (10);
			// If the player does not have enemy, the player dies.
			if (PlayerSettings.Energy == 0) 
			{
				Destroy (collision.gameObject);
			}

			Destroy (this.gameObject);
		}

	}
}
