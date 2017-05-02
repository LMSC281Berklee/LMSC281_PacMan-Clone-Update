//LMSC-281 Logic and Programming
//PacMan simple example, converted to C#
//from http://www.tosos.com/PacManClone.zip; found on http://forum.unity3d.com/threads/pac-man-clone-in-60-lines-of-code.56054/
//AI updates modified from the enemy movement tutorial here: http://www.palladiumgames.net/tutorials/beginning-unity-and-c-game-development/beginning-unity-and-c-part-11/
//by Jeanine Cowen - Spring 2017

using UnityEngine;
using System.Collections;

public class GhostControlTargets : MonoBehaviour {

	//this variable allows for flexibility in the ghosts' movement speed, it is public so that it can be applied differently, per ghost
	public int movementSpeed;
	
	//starting fresh, set all targets first

	//in order to move toward the given target we need to store the player, ghost, and possible other target transform locations
	Transform playerTransform;
	Transform ghostTransform;
	Transform targetTransform;

	//we also need to see if a wall is blocking a path
	bool leftObject;
	bool rightObject;
	bool forwardObject;


	//initialize the ghost's transform
	void Awake () {
		ghostTransform = transform;
	}

	//find the location of the player when the level starts, make sure to set the tag in the inspector
	void Start () {
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	//on each cycle, check the possible directions of travel
	void Update () {
		//check for walls around the ghost
		forwardObject = Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), 1);
		rightObject = Physics.Raycast (transform.position, transform.TransformDirection(Vector3.right), 1);
		leftObject = Physics.Raycast (transform.position, transform.TransformDirection(Vector3.left), 1);

		//if all directions are available, check to see where the target is and move toward it
		if (!forwardObject && !rightObject && !leftObject) {
			//set direction to face
			if ((ghostTransform.position.x >= playerTransform.position.x) && (ghostTransform.position.z >= playerTransform.position.z)) {
				ghostTransform.rotation = Quaternion.Euler (0, 270, 0);
			} else if ((ghostTransform.position.z <= playerTransform.position.z) && (ghostTransform.position.x <= playerTransform.position.x)) {
				ghostTransform.rotation = Quaternion.Euler (0, 0, 0);
			} else {
				ghostTransform.rotation = Quaternion.Euler (0, 90, 0);
			}
		} else if (!forwardObject) {
			ghostTransform.position += ghostTransform.forward * movementSpeed * Time.deltaTime;
		}
		//if we must choose a direction we choose left first
		else if (!leftObject) {
			ghostTransform.transform.Rotate (0, 270, 0);
		}
		//or rotate right if spot is available, ghost will move forward on next cycle
		else {
			ghostTransform.transform.Rotate (0, 90, 0);
		}
		ghostTransform.position += ghostTransform.forward * movementSpeed * Time.deltaTime;
	}


//		//keep moving forward if available
//		if (!forwardObject) {
//			ghostTransform.position += ghostTransform.forward * movementSpeed * Time.deltaTime;
//		}
//		//or rotate left if spot is available, ghost will move forward on next cycle
//		else if (!leftObject) {
//			ghostTransform.transform.Rotate (0, 270, 0);
//		}
//		//or rotate right if spot is available, ghost will move forward on next cycle
//		else {
//			ghostTransform.transform.Rotate (0, 90, 0);
//		}
//

//		//set direction to face
//		if ((ghostTransform.position.x >= playerTransform.position.x) && (ghostTransform.position.z >= playerTransform.position.z)) {
//			ghostTransform.rotation = Quaternion.Euler (0, 270, 0);
//		} else if ((ghostTransform.position.z <= playerTransform.position.z) && (ghostTransform.position.x <= playerTransform.position.x)) {
//			ghostTransform.rotation = Quaternion.Euler (0, 0, 0);
//		} else {
//			ghostTransform.rotation = Quaternion.Euler (0, 90, 0);
//		}
//	}

	
//		//each ghost targets a different area around the player
//		private GameObject target;
//		private Vector3 targetPoint;
//		private Quaternion targetRotation;

//	//we only want our ghosts to chase when the player is out of range for Clyde
//	public float detectionRange = 10;
//

//
//	
//	
//	
//	// Update is called once per frame
//	void Update () {
////		//rotate toward target once per second, this also allows us to move in a forward direction more readily
////		ghostTransform.rotation = Quaternion.Slerp(ghostTransform.rotation, Quaternion.LookRotation(playerTransform.position - ghostTransform.position), rotationSpeed * Time.deltaTime);
//
//		//use different targets based on the ghost character
//		switch (this.gameObject.name) {
//		case "Blinky":
//			//we need to set this ghost's target position. Pinky looks directly at the player
//			//rotate toward target once per second, this also allows us to move in a forward direction more readily
//			ghostTransform.rotation = Quaternion.Slerp(ghostTransform.rotation, Quaternion.LookRotation(playerTransform.position - ghostTransform.position), rotationSpeed * Time.deltaTime);
//			break;
//		case "Pinky":
//			targetPoint = new Vector3((target.transform.position.x-1), 0, (target.transform.position.z-1)) - transform.position;
//			targetRotation = Quaternion.LookRotation (targetPoint);
//			ghostTransform.rotation = Quaternion.Slerp(ghostTransform.rotation, targetRotation, Time.deltaTime * 2.0f);
//			break;
//		default:
//			break;
//		}
//
//	}
}
