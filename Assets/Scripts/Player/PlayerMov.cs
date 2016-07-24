using UnityEngine;
using System.Collections;

public class PlayerMov : MonoBehaviour {

    [SerializeField]
    public string inputNameHor = "Horizontal";

    [SerializeField]
    public string inputNameVer = "Vertical";

    [SerializeField]
    float fuerza = 5f;
	float knockbackF = 15f;  // Force we can apply when the player hits the enemy.

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

	void OnCollisionEnter2D(Collision2D collision)
	{
		// If the player collide with an enemy, the player move to the inverse direction.
		if (collision.gameObject.tag == "Enemy") 
		{
			Vector2 knockbackDir = -1 * collision.relativeVelocity.normalized * knockbackF;
			body.AddForce(knockbackDir, ForceMode2D.Impulse);
		}
	}
}
