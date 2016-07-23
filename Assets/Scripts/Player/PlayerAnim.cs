using UnityEngine;
using System;

public class PlayerAnim : MonoBehaviour {

    private Animator anim;

    [SerializeField]
    Rigidbody2D objetivo;
    /*
    [SerializeField]
    PlayerMov player;*/

    [SerializeField]
    float minVelDeteccion = 1f;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        anim.SetInteger("Horizontal", Convert.ToInt32(objetivo.velocity.x > minVelDeteccion) - Convert.ToInt32(objetivo.velocity.x < -minVelDeteccion));
        anim.SetInteger("Vertical", Convert.ToInt32(objetivo.velocity.y > minVelDeteccion) - Convert.ToInt32(objetivo.velocity.y < -minVelDeteccion));
        
        /*
        anim.SetInteger("Horizontal", Convert.ToInt32(Input.GetAxis(player.inputNameHor) > 0) - Convert.ToInt32(Input.GetAxis(player.inputNameHor) < 0));
        anim.SetInteger("Vertical", Convert.ToInt32(Input.GetAxis(player.inputNameVer) > 0) - Convert.ToInt32(Input.GetAxis(player.inputNameVer) < 0));
        */
    }
}
