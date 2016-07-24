using UnityEngine;
using System.Collections;

public class memoryInteraction : MonoBehaviour {

    [SerializeField]
    int id;
    
    memoriesManager manager;
    Animator anim;
    bool taken = false;

	void Start()
	{
        manager = GameObject.Find("MemoriesManager").GetComponent<memoriesManager>();
        anim = GetComponent<Animator>();
    }
		
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player" && !taken) {
            taken = true;
            anim.SetTrigger("Taken");
        }
	}

    public void end() {
        manager.elegirRecuerdo(id);
        globalSettings.playerSettings.setMemoryAmount(10);
        Destroy(this.gameObject);
    }

}
