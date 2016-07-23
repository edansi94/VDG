using UnityEngine;
using System.Collections;

public class Camara : MonoBehaviour {

    [SerializeField]
    Transform objetivo;

    [SerializeField]
    float deltaMin = 0.1F;

    [SerializeField]
    float lerpDuration = 3f;

    private float starTime;
    

    private bool moving;
    private Vector3 posO;

	void FixedUpdate () {
        if (moving)
        {
            // Recalcular si se movio
            Vector3 temp = new Vector3(objetivo.position.x, objetivo.position.y, transform.position.z);
            if (Vector3.Distance(posO, temp) > deltaMin)
            {
                posO = temp;
            }

            // Dejar de pensar que se mueve si ya esta muy cerca
            if (Vector3.Distance(posO, transform.position) <= deltaMin)
            {
                moving = false;
            }
            else
            {
                float t = Mathf.Clamp((Time.time - starTime) / lerpDuration, 0f, 1f);
                float fractJourney = t * t * t * (t * (t * 6f - 15f) + 10f);
                transform.position = Vector3.LerpUnclamped(transform.position, posO, fractJourney);
            }
        }
        else
        {
            Vector3 temp = new Vector3(objetivo.position.x, objetivo.position.y, transform.position.z);
            if (Vector3.Distance(transform.position, temp) > deltaMin)
            {
                starTime = Time.time;
                posO = temp;
                moving = true;
            }
        }
        
	}
}
