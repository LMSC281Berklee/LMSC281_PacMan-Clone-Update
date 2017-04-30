//LMSC-281 Logic and Programming
//PacMan simple example, converted to C#
//from http://www.tosos.com/PacManClone.zip; found on http://forum.unity3d.com/threads/pac-man-clone-in-60-lines-of-code.56054/
//by Jeanine Cowen - Spring 2017

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DestroyPellet : MonoBehaviour {

	//use to display the player score
	public GUIText scoreDisplay;



	//determine individual prefab values
	public int smallPelletScore = 10;
	public int superPelletScore = 100;
	static public int ghostEatingScore = 500;
	static public bool superPowered = false;
	static public float counter = 20;






	//starting score
	static public int score = 0;


	//send the score to the screen on every update cycle
	void Update () {
		scoreDisplay.text = "Score: " + score;





	}

	//when the player runs into a pellet, add to the score and then destroy
	void OnTriggerEnter (Collider other) 
	{
		if (other.name == "BasicPellet(Clone)") 
		{
			score += smallPelletScore;
			Destroy (other.gameObject);
		} 
		else if (other.name == "SuperPellet(Clone)") 
		{
			score += superPelletScore;
			Destroy (other.gameObject);

			if (superPowered == false) 
			{
				superPowered = true;

		
				Debug.Log("superPower"); //testing to make sure my condition works
				counter -= Time.deltaTime;
					
					if (counter <= 0) 
					{
						
						superPowered = false;
						Debug.Log ("normal");
						
					}
			

				}



			}

			
	}

}


	

