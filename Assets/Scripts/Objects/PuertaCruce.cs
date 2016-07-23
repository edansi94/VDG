using UnityEngine;
using System.Collections;

public class PuertaCruce : MonoBehaviour {

    private Puerta door;
	// Use this for initialization
	void Start () {
        door = transform.parent.GetComponent<Puerta>();
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            door.cruzando = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            door.cruzando = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            door.cruzando = false;
        }
    }
}
