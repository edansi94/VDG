using UnityEngine;
using System.Collections;

public interface I_Interactuable {
    // Si esta encendido
    bool on { get; }
    // Si solo puede ser interactuado una vez
    bool oneWay { get; set; }
    // Si fue interactuado, para oneWay
    bool interactuado { get; set; }
    // Respeta si es oneway
    void Interact();
    // No respeta si es oneway
    void SuperInteract();
}
