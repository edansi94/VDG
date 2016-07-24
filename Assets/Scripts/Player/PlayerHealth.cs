using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	private GameObject globalE;
	private globalSettings.playerSettings PlayerSettings;

	public int currentHealth;
	public Slider healthSlider;
	public Image damageImage;
	public float flashSpeed = 5f;
	public Color flashColour = new Color (1f, 0f, 0f, 0.1f);

	bool damaged;

	// Use this for initialization
	void Start () {
		globalE = GameObject.FindGameObjectWithTag ("MainCamera");
		PlayerSettings = globalE.GetComponent<globalSettings> ().PlayerSettings;
		currentHealth  = PlayerSettings.Energy;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void TakeDamage (int amount)
	{
		damaged = true;
		currentHealth -= amount;
		PlayerSettings.setEnergy (-amount);
		healthSlider.value = currentHealth;
		Debug.Log (PlayerSettings.Energy);
		if (currentHealth <= 0) {
			float fadeTime = GameObject.Find ("Main Camera").GetComponent<Fading> ().BeginFade (1);
			StartCoroutine (FadeEffect (fadeTime  * 2));
			SceneManager.LoadScene("GameOver");
		}
	}

	public IEnumerator FadeEffect(float fadeTime)
	{
		yield return new WaitForSeconds (fadeTime);
	}
}
