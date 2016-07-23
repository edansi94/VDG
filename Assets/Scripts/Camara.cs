using UnityEngine;
using System.Collections;

public class Camara : MonoBehaviour {

    [SerializeField]
    Transform objetivo;

    [SerializeField]
    float velocidad = 2f;

    [SerializeField]
    float deltaMin = 0.1F;

    private float starTime;
    private float journeyLength;

    private bool moving;
    private Vector3 posO;

    void Start() {
        velocidad /= 100f;
    }
	void FixedUpdate () {
        if (moving)
        {
            // Recalcular si se movio
            Vector3 temp = new Vector3(objetivo.position.x, objetivo.position.y, transform.position.z);
            if (Vector3.Distance(posO, temp) > deltaMin)
            {
                //starTime = Time.time;
                posO = temp;
                journeyLength = Vector3.Distance(posO, transform.position);
            }

            // Dejar de pensar que se mueve si ya esta muy cerca
            if (Vector3.Distance(posO, transform.position) <= deltaMin)
            {
                moving = false;
            }
            else
            {
                float fractJourney = (Time.time - starTime) * velocidad / journeyLength;
                transform.position = Vector3.SlerpUnclamped(transform.position, posO, fractJourney);
            }
        }
        else
        {
            Vector3 temp = new Vector3(objetivo.position.x, objetivo.position.y, transform.position.z);
            if (Vector3.Distance(transform.position, temp) > deltaMin)
            {
                starTime = Time.time;
                posO = temp;
                journeyLength = Vector3.Distance(posO, transform.position);
                moving = true;
            }
        }
        
	}
}
