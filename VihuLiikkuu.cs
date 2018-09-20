using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class VihuLiikkuu : MonoBehaviour {

	public int EnemySpeed;
	public int xMoveDirection;
	public bool facingRight = false;

	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast (transform.position, new Vector2 (xMoveDirection, 0));
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (xMoveDirection, 0) * EnemySpeed;
		if (hit.distance < 0.8f){
			Flip ();
			if (hit.collider.tag == "Respawn"){
				Destroy (hit.collider.gameObject);
				SceneManager.LoadScene ("Tikku-Ukko");

			}


	}

	}
	void Flip (){
		if ( xMoveDirection > 0){
			xMoveDirection = -1;
		
		} else {
			xMoveDirection = 1;
		}
	}
		void FlipObject() {
			facingRight = !facingRight;
			Vector2 localScale = gameObject.transform.localScale;
			localScale.x *= -1;
			transform.localScale = localScale;


	}
}
