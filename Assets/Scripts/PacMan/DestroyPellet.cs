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
	static public int ghostEatingScore = 500;
	//public int colorTimer = 0;
	static public bool superPowered = false;
	static public int counter = 0;
	//public Color pinkyColor = new Color(255, 126, 212, 225);
	//public Color blinkyColor = new Color (255, 0, 28, 191);
	//public Color inkyColor = new Color(69, 231, 255, 199);
	//public Color clydeColor = new Color(186, 145, 62, 213);





	//starting score
	static public int score = 0;

	//send the score to the screen on every update cycle
	void Update () {
		scoreDisplay.text = "Score: " + score;
	}

	//when the player runs into a pellet, add to the score and then destroy
	void OnTriggerEnter (Collider other) {
		if (other.name == "BasicPellet(Clone)") {
			score += smallPelletScore;
		} else if (other.name == "SuperPellet(Clone)") {
			score += superPelletScore;
		Destroy (other.gameObject);

			if (superPowered == false) {
				superPowered = true;
				Debug.Log("superPower"); //testing to make sure my condition works
				counter++;
				//while (counter < 20) {
					//if (other.tag == "enemy") {
						//score += ghostEatingScore;
						//Destroy (other.gameObject);
						if (counter >= 20) {
							counter = 0;
							superPowered = false;
			//change "A" value of ghost colors to .2 and then back to original in half second intervals
		

						}
					}

				}
			}

		}
	

