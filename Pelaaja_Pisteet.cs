using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pelaaja_Pisteet : MonoBehaviour {

	private float timeLeft = 120;
	public int PelaajaPisteet = 0;
	public GameObject timeLeftUI;
	public GameObject PisteetUI;


	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;	
		timeLeftUI.gameObject.GetComponent<Text> ().text = ("Time Left: " + (int)timeLeft);
		PisteetUI.gameObject.GetComponent<Text> ().text = ("Pisteet: " + (int)PelaajaPisteet);
		if (timeLeft < 0.1f) {
			SceneManager.LoadScene ("Tikku-Ukko");
	}
}
	void OnTriggerEnter2D (Collider2D trig){
		if (trig.gameObject.tag == "Finish"){
		CountScore ();
			Destroy (trig.gameObject);
			Debug.Log ("Pääsi Maaliin!");
			Debug.Log ("Siirrytään voittoruutuun");
			SceneManager.LoadScene ("Voitit Pelin");
	
		}
		if (trig.gameObject.tag == "kolikko"){
			PelaajaPisteet += 100;
			Destroy (trig.gameObject);
			Debug.Log ("Nappasi kolikon!");
	}
		if (trig.gameObject.tag == "LootBox"){
			PelaajaPisteet += 151;
			Destroy (trig.gameObject);
			Debug.Log ("Rikkoi Laatikon!");

	}
		if (trig.gameObject.tag == "Lopeta"){
			Debug.Log ("Poistutaan");
			SceneManager.LoadScene ("Voitit Pelin");
		}
		if (trig.gameObject.tag == "Aloita"){
			Debug.Log ("Siirrytään Peliin");
			SceneManager.LoadScene ("Tikku-Ukko");
		}
}

	void CountScore (){
		PelaajaPisteet = PelaajaPisteet + (int)(timeLeft * 30);
		Debug.Log ("Pisteesi:" + PelaajaPisteet);
	}
}
