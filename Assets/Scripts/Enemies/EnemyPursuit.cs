using UnityEngine;
using System.Collections;

public class EnemyPursuit : MonoBehaviour {

    [SerializeField]
    float fuerza = 10f;

    [SerializeField]
    float maximaDistanciaPersecusion = 20f;

    [SerializeField]
    public bool cutPursuitByDistance = false;

    private Behaviour[] comps;

    Transform target;
    private Rigidbody2D body;
    private Vector2 dir;
    private Collider2D trigger;
    bool started = false;
    bool persiguiendo = false;
	// Use this for initialization
	void Start () {
        if (!started)
        {
            body = transform.parent.GetComponent<Rigidbody2D>();
            trigger = transform.GetComponent<Collider2D>();
            comps = transform.parent.GetComponents<Behaviour>();
            Apagar();
        }
        started = true;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (persiguiendo)
        {
            dir = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
            if (cutPursuitByDistance && dir.magnitude > maximaDistanciaPersecusion)
            {
                Apagar();
                persiguiendo = false;
            }
            dir.Normalize();
            body.AddForce(dir * fuerza);
        }
        
    }

    public void Activar(Transform obj) {
        target = obj;
        for (int i = 0; i < comps.Length; i++)
        {
            comps[i].enabled = true;
        }
        this.enabled = true;
        trigger.enabled = true;
        persiguiendo = true;
    }

    public void Apagar() {
        for (int i = 0; i < comps.Length; i++)
        {
            comps[i].enabled = false;
        }
        this.enabled = false;
        trigger.enabled = true;
        persiguiendo = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Activar(other.transform);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && !this.enabled)
        {
            Activar(other.transform);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Apagar();
        }
    }
}
