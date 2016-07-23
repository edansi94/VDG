using UnityEngine;
using System.Collections;

public class PlayerMov : MonoBehaviour {

    [SerializeField]
    string inputNameHor = "Horizontal";

    [SerializeField]
    const string inputNameVer = "Vertical";

    [SerializeField]
    float fuerza = 5f;

    private Rigidbody2D body;
    private Vector2 dir;

    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();
    }
	
	// Fixed Update is called once per physics tick
	void FixedUpdate () {
        dir = new Vector2(Input.GetAxis(inputNameHor), Input.GetAxis(inputNameVer));
        dir = dir.normalized * fuerza;
        if (dir != Vector2.zero)
        {
            body.AddForce(dir);
        }
	}
}
