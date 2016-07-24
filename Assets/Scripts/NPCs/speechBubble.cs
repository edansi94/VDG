using UnityEngine;
using System.Collections;

public class speechBubble : MonoBehaviour {

	public Canvas dialogBubble;

	void Start()
	{
		dialogBubble.enabled = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			dialogBubble.enabled = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") {
			dialogBubble.enabled = false;
		}
	}
}
