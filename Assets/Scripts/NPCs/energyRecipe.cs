using UnityEngine;
using System.Collections;

public class energyRecipe : MonoBehaviour, I_Interactuable
{

    // Collider del objeto es trigger y es mas grande que el collider fisico (el que se encargara de ver choques)

    // OneWay es que una vez interactuado no se puede volver a interactuar
    [SerializeField]
    bool oneWay = false;

    // Para esta cosa, deberias dejarlo en encendido false porque es solo una vez
    [SerializeField]
    bool encendido = false;

    bool I_Interactuable.on { get { return encendido; } }

    bool I_Interactuable.oneWay { get { return oneWay; } set { oneWay = value; } }

    bool interactuado = false;
    bool I_Interactuable.interactuado { get { return interactuado; } set { interactuado = value; } }

    private Animator anim;


    [SerializeField]
    int cantidadAQuitar = 10;

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
        // Aqui se quita la energia
        globalSettings.playerSettings.setEnergy(cantidadAQuitar);
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
