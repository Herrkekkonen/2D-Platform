using UnityEngine;
using System.Collections;

public class VihuHealth : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.y < -10) {
			Destroy (gameObject);
		
	}
	}}
