using UnityEngine;
using System.Collections;

public class Bombillo : MonoBehaviour, I_Interactuable {

    [SerializeField]
    bool oneWay = false;

    [SerializeField]
    bool encendido = false;

    bool I_Interactuable.on { get { return encendido; } }

    bool I_Interactuable.oneWay { get { return oneWay; } set { oneWay = value; } }

    bool interactuado = false;
    bool I_Interactuable.interactuado { get { return interactuado; } set { interactuado = value; } }

    private Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        if (encendido)
        {
            anim.SetTrigger("Interactuar");
        }
    }

    void I_Interactuable.Interact()
    {
        if (!oneWay || !interactuado)
        {
            ((I_Interactuable)this).SuperInteract();
        }
    }

    void I_Interactuable.SuperInteract()
    {
        encendido = !encendido;
        anim.SetTrigger("Interactuar");
        interactuado = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Interact>().inscribirse((I_Interactuable)this);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Interact>().salir((I_Interactuable)this);
        }
    }
}
