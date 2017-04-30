//LMSC-281 Logic and Programming
//PacMan simple example, converted to C#
//from http://www.tosos.com/PacManClone.zip; found on http://forum.unity3d.com/threads/pac-man-clone-in-60-lines-of-code.56054/
//by Jeanine Cowen - Spring 2017

using UnityEngine;
using System.Collections;

public class GhostControl : MonoBehaviour {

	//allow each enemy type to have different movement settings
	public float howLong = 1.0f;
	public float howFast = 8.0f;


	//determine the update frequency 
	private float nextUpdate = 1.0f;

	//give each enemy a place to move to
	private Vector3 direction;
	

	// Update is called once per frame
	void Update () {
		if (Time.time > nextUpdate) {
			nextUpdate = Time.time + (howLong * Random.value);

			//set the position to move to
			direction = Random.onUnitSphere;
			direction.y = 0.0f;
			direction.Normalize ();
			direction = direction * howFast;
			direction.y = 1.5f - transform.position.y;
		}

		//move the enemy
		CharacterController controller = GetComponent<CharacterController>();
		controller.Move (direction * Time.deltaTime);
	}
}
