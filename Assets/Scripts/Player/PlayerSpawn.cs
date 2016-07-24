using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position = GameObject.Find("MemoriesManager").GetComponent<memoriesManager>().dondeAparecer();
        Transform camara = GameObject.Find("Main Camera").transform;
        camara.position = new Vector3(transform.position.x, transform.position.y, camara.position.z);
    }
}
