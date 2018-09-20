using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour {


	public int health;
	public bool hasDied;




	 
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.y < -5) {
			Die ();



	}
	}

	void Die () {
		SceneManager.LoadScene ("Tikku-Ukko");

	
}
}
