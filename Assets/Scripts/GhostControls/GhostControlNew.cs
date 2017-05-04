//LMSC-281 Logic and Programming
//PacMan simple example, converted to C#
//from http://www.tosos.com/PacManClone.zip; found on http://forum.unity3d.com/threads/pac-man-clone-in-60-lines-of-code.56054/
//AI updates modified from the enemy movement tutorial here: http://www.palladiumgames.net/tutorials/beginning-unity-and-c-game-development/beginning-unity-and-c-part-11/
//by Jeanine Cowen - Spring 2017

using UnityEngine;
using System.Collections;

public class GhostControlNew : MonoBehaviour {

	//these variables allow for flexibility in the ghosts' movement and rotatoin speed, they are public so that they can be applied differently, per ghost
	public int movementSpeed;
	public int rotationSpeed;

	//we only want our ghosts to chase when the player is in range, which can be set individually for each ghost
	public float detectionRange = 10;

	//in order to move toward the player we need to store both the enemy and player transform locations
	Transform playerTransform;
	Transform ghostTransform;

	//each ghost targets a different area around the player
	private GameObject target;
	private Vector3 targetPoint;
	private Quaternion targetRotation;

	//need a check to see if a wall is blocking a path
	bool leftObject;
	bool rightObject;
	bool forwardObject;
	
	//initialize the ghost's transform
	void Awake () {
		ghostTransform = transform;
	}

	void Start () {
		//find the location of the player when the level starts, make sure to set the tag in the inspector
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		target = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
//		//rotate toward target once per second, this also allows us to move in a forward direction more readily
//		ghostTransform.rotation = Quaternion.Slerp(ghostTransform.rotation, Quaternion.LookRotation(playerTransform.position - ghostTransform.position), rotationSpeed * Time.deltaTime);

		//check for walls around the ghost
		forwardObject = Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), 1);
		rightObject = Physics.Raycast (transform.position, transform.TransformDirection(Vector3.right), 1);
		leftObject = Physics.Raycast (transform.position, transform.TransformDirection(Vector3.left), 1);

		//use different targets based on the ghost character
		switch (this.gameObject.name) {
		case "Blinky":
			//we need to set this ghost's target position. Blinky looks directly at the player
			//rotate toward target once per second, this also allows us to move in a forward direction more readily
			ghostTransform.rotation = Quaternion.Slerp(ghostTransform.rotation, Quaternion.LookRotation(playerTransform.position - ghostTransform.position), rotationSpeed * Time.deltaTime);
			break;
		case "Pinky":
			targetPoint = new Vector3((target.transform.position.x-1), 0, (target.transform.position.z-1)) - transform.position;
			targetRotation = Quaternion.LookRotation (targetPoint);
			ghostTransform.rotation = Quaternion.Slerp(ghostTransform.rotation, targetRotation, Time.deltaTime * 2.0f);
			break;
		default:
			break;
		}

		//move toward target
		if (!forwardObject) {//move forward if no obstacle
			ghostTransform.position += ghostTransform.forward * movementSpeed * Time.deltaTime;
		}
		else if (!rightObject) {//move to the right if no obstacle
			ghostTransform.position += ghostTransform.right * movementSpeed * Time.deltaTime;
		}
		else if (!leftObject) {//move to the left if no obstacle
			ghostTransform.transform.Rotate(0,90,0);
			ghostTransform.position += ghostTransform.forward * movementSpeed * Time.deltaTime;
		}
		else {//turn around if blocked in all directions
			ghostTransform.transform.Rotate(0,180,0);
			ghostTransform.position += ghostTransform.forward * movementSpeed * Time.deltaTime;
		}


	}
}
