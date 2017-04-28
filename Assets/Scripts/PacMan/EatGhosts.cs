using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatGhosts : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	 //Update is called once per frame
	void OnTriggerEnter(Collider other) {
		while (DestroyPellet.superPowered == true && DestroyPellet.counter < 20) {
			if (other.tag == "enemy") {
			DestroyPellet.score += DestroyPellet.ghostEatingScore;
			Destroy (other.gameObject);

			}
			
		}
	}
		
}

