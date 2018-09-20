using UnityEngine;
using System.Collections;

public class UkkeliLiikkuu : MonoBehaviour {

	public int playerSpeed = 10;
	private bool facingRight = false;
	public int playerJumpPower = 1250;
	private float moveX;
	private bool isGrounded;
	private float distanceToBottomOfPlayer = 1.0f;
	private float distanceToTheTopofplayer = 1f;
	

	// Update is called once per frame
	void Update () {
		PlayerMove ();
		PlayerRaycast ();
	
	}
	void PlayerMove() {
		//Controls
		moveX = Input.GetAxis ("Horizontal");
		if (Input.GetButtonDown ("Jump") && isGrounded == true){
			Jump();
		}
		//Animations
				//Kävely
		if (moveX != 0) {
			GetComponent<Animator>().SetBool ("Juoksu", true);
		} else {
			GetComponent<Animator>().SetBool ("Juoksu", false);
		}

				//Hyppy
			
		if (isGrounded == false) {
			GetComponent<Animator> ().SetBool ("Hyppy", true);
		} else {
			GetComponent<Animator>().SetBool ("Hyppy", false);
		}

		//Player Direction
		if (moveX < 0.0f && facingRight == false){
			FlipPlayer ();
		} else if (moveX > 0.0f && facingRight == true) { 
			FlipPlayer ();
		}
		//Physics
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);


	}

	void Jump() {
		//Jumping Code
		GetComponent<Rigidbody2D> ().AddForce (Vector2.up * playerJumpPower);
		isGrounded = false;
	}

	void FlipPlayer() {
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;

	}



		void PlayerRaycast () {
		//Ray Up
		RaycastHit2D rayUp = Physics2D.Raycast (transform.position, Vector2.up);
		if (rayUp != null && rayUp.collider != null && rayUp.distance <distanceToTheTopofplayer && rayUp.collider.tag == "LootBox") {
			gameObject.GetComponent<Pelaaja_Pisteet> ().PelaajaPisteet += 150;
			Debug.Log ("Rikoit laatikon!");
			Destroy (rayUp.collider.gameObject);
		}
		//Ray Down
			RaycastHit2D rayDown = Physics2D.Raycast (transform.position, Vector2.down);
		if (rayDown != null && rayDown.collider != null && rayDown.distance <distanceToBottomOfPlayer && rayDown.collider.tag == "Vihu") {
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 1000);
			rayDown.collider.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 200);
			rayDown.collider.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 10;
			rayDown.collider.gameObject.GetComponent<Rigidbody2D> ().freezeRotation = false;
			rayDown.collider.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			rayDown.collider.gameObject.GetComponent<VihuLiikkuu> ().enabled = false;
		}
		if (rayDown != null && rayDown.collider != null && rayDown.distance <distanceToBottomOfPlayer && rayDown.collider.tag != "Vihu") {
			isGrounded = true;
	
		}

	}

}