using UnityEngine;
using System.Collections;

public class speechBubble : MonoBehaviour {

	public Canvas dialogBubble;
    [SerializeField]
    AudioClip hablar;

    private AudioSource fuente;

    bool hablando = false;

    void Start()
	{
		dialogBubble.enabled = false;
        fuente = GetComponent<AudioSource>();
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			dialogBubble.enabled = true;
            if (!hablando)
            {
                hablando = true;
                fuente.PlayOneShot(hablar);
            }
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") {
			dialogBubble.enabled = false;
            hablando = false;
        }
	}
}
