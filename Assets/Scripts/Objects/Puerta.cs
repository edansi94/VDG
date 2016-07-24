using UnityEngine;
using System.Collections;

public class Puerta : MonoBehaviour, I_Interactuable {

    [SerializeField]
    bool oneWay = false;

    [SerializeField]
    bool abierto = false;

    bool I_Interactuable.on { get { return abierto; } }

    bool I_Interactuable.oneWay { get { return oneWay; } set { oneWay = value; } }

    bool interactuado = false;
    bool I_Interactuable.interactuado { get { return interactuado; } set { interactuado = value; } }

    [SerializeField]
    Collider2D puertaFisica;

    public bool cruzando = false;

    private Animator anim;

    [SerializeField]
    AudioClip cerrar;

    private AudioSource fuente;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        fuente = GetComponent<AudioSource>();
        if (abierto)
        {
            anim.SetTrigger("Interactuar");
            puertaFisica.isTrigger = true;
        }
        else
        {
            puertaFisica.isTrigger = false;
        }
    }

    void I_Interactuable.Interact() {
        if ((!oneWay || !interactuado) && !cruzando)
        {
            ((I_Interactuable)this).SuperInteract();
        }
    }

    void I_Interactuable.SuperInteract()
    {
        abierto = !abierto;
        anim.SetTrigger("Interactuar");
        puertaFisica.isTrigger = abierto;
        interactuado = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
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

    public void sonidoCerrar() {
        fuente.PlayOneShot(cerrar);
    }
}
