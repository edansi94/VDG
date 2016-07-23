using UnityEngine;
using System.Collections.Generic;

public class Interact : MonoBehaviour {

    private HashSet<I_Interactuable> inscritos = new HashSet<I_Interactuable>();

    private bool presiono = false;


    
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Interact")) {
            presiono = true;
        }
	}

    void FixedUpdate() {
        if (presiono)
        {
            foreach (I_Interactuable inscrito in inscritos)
            {
                inscrito.Interact();
            }
            presiono = false;
        }
    }

    public void inscribirse(I_Interactuable objeto) {
        inscritos.Add(objeto);
    }

    public void salir(I_Interactuable objeto) {
        inscritos.Remove(objeto);
    }
}
