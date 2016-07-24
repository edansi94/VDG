using UnityEngine;
using System.Collections.Generic;

public class PlayerActivateOthers : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy")
        {
            print("sup");
            other.GetComponent<EnemyPursuit>().Activar(transform);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            print("bye");
            other.GetComponent<EnemyPursuit>().Apagar();
        }
    }
}
