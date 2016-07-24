using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Alpha : MonoBehaviour {

	public Image iconHealth;

	// Use this for initialization
	void Start () {
		iconHealth.color = new Color (iconHealth.color.r/2, iconHealth.color.g/2, iconHealth.color.b/2, 1f);
	}
}
