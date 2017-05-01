//LMSC-281 Logic and Programming
//PacMan simple example, converted to C#
//from http://www.tosos.com/PacManClone.zip; found on http://forum.unity3d.com/threads/pac-man-clone-in-60-lines-of-code.56054/
//by Jeanine Cowen - Spring 2017

using UnityEngine;
using System.Collections;

public class DestroyPellet : MonoBehaviour {

	//use to display the player score
	public GUIText scoreDisplay;

	//determine individual prefab values
	public int smallPelletScore = 10;
	public int superPelletScore = 100;

	//starting score
	private int score = 0;

	//send the score to the screen on every update cycle
	void Update () {
		scoreDisplay.text = "Score: " + score;
	}

	//when the player runs into a pellet, add to the score and then destroy
	void OnTriggerEnter (Collider other) {
		if (other.name == "BasicPellet(Clone)") {
			score += smallPelletScore;
			Destroy (other.gameObject);
		} else if (other.name == "SuperPellet(Clone)") {
			score += superPelletScore;
			Destroy (other.gameObject);
		}
	}
}
