using UnityEngine;
using System.Collections;

public class PlayerSound : MonoBehaviour {

    AudioSource fuente;
    [SerializeField]
    AudioClip hit;

	// Use this for initialization
	void Start () {
        fuente = GetComponent<AudioSource>();
    }

    public void ouch() {
        fuente.PlayOneShot(hit);
    }
}
