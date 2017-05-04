//LMSC-281 Logic and Programming
//PacMan simple example, converted to C#
//from http://www.tosos.com/PacManClone.zip; found on http://forum.unity3d.com/threads/pac-man-clone-in-60-lines-of-code.56054/
//AI updates modified from the enemy movement tutorial here: http://www.palladiumgames.net/tutorials/beginning-unity-and-c-game-development/beginning-unity-and-c-part-11/
//by Jeanine Cowen - Spring 2017

using UnityEngine;
using System.Collections;

public class GhostControlNew : MonoBehaviour {

	//these variables allow for flexibility in the ghosts' movement and rotation speed, they are public so that they can be applied differently, per ghost
	int movementSpeed = 3;
	int rotationSpeed = 3;

	//we only want our ghosts to chase when the player is in range, which can be set individually for each ghost
//	int detectionRange = 10;
//
//	int attackRange = 1;
//	float timeToMeasureAgainst = 0.0f;

	//in order to move toward the player we need to store both the enemy and player transform locations
	Transform playerTransform;
	Transform myTransform;

//	//each ghost targets a different area around the player
//	private GameObject target;
//	private Vector3 targetPoint;
//	private Quaternion targetRotation;

	//need a check to see if a wall is blocking a path
	bool leftObject;
	bool rightObject;
	bool forwardObject;

	public bool inGhostHouse = true;

	Vector3 origin = new Vector3(0,0,6);

	//initialize the ghost's transform
	void Awake () {
		myTransform = transform;
	}

	void Start () {
		//find the location of the player when the level starts, make sure to set the tag in the inspector
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		//target = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		//check for walls around the ghost
		forwardObject = Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), 1);
		rightObject = Physics.Raycast (transform.position, transform.TransformDirection(Vector3.right), 1);
		leftObject = Physics.Raycast (transform.position, transform.TransformDirection(Vector3.left), 1);


		//JC when the game starts... we need tp update this if we have time
		if ((transform.position == origin) & inGhostHouse) {
			inGhostHouse = !inGhostHouse;
		}

		//JC when you are in the ghostHouse, move to get out
		//JC this movement will need to be adjusted if we have time
		if (inGhostHouse) {
			transform.position = Vector3.MoveTowards(transform.position, origin, Time.deltaTime);
		}
		//JC keep ghost moving forward when other paths are blocked
		else if (!forwardObject) {
			myTransform.position = myTransform.position + myTransform.forward * movementSpeed * Time.deltaTime;
		}

		//if forward is blocked check to the right and turn if it isn't blocked and if pacman is to the right
		else if (!rightObject && (myTransform.position.x < playerTransform.position.x) && (Mathf.Round(transform.rotation.y) != 90)) {
			transform.rotation *= Quaternion.Euler(0, 90, 0); // this add a 90 degrees Y rotation
		}

		//if forward is blocked and right are blocked and/or the player is not to the right, turn to the left
		else if (!leftObject) {
			transform.rotation *= Quaternion.Euler(0, 270, 0); // this adds a 270 degrees Y rotation
		}
		else {
			myTransform.position = myTransform.position + myTransform.forward * movementSpeed * Time.deltaTime;
		}

		//use different targets based on the ghost character
//		switch (this.gameObject.name) {
//		case "Blinky":
//			//we need to set this ghost's target position. Blinky looks directly at the player
//			//rotate toward target once per second, this also allows us to move in a forward direction more readily
//
//			//ghostTransform.rotation = Quaternion.Slerp (ghostTransform.rotation, Quaternion.LookRotation (playerTransform.position - ghostTransform.position), rotationSpeed * Time.deltaTime);
//			targetPoint = new Vector3 ((target.transform.position.x), 0, (target.transform.position.z)) - transform.position;
//			targetRotation = Quaternion.LookRotation (targetPoint);
//			ghostTransform.rotation = Quaternion.Slerp(ghostTransform.rotation, targetRotation, Time.deltaTime * 2.0f);
//			//Debug.Log (targetPoint);
//			//ghostTransform.position += ghostTransform.forward * movementSpeed * Time.deltaTime;
//
//			if (!forwardObject) {//move forward if no obstacle
//				Debug.Log("hit forward");
//				ghostTransform.position += ghostTransform.forward * movementSpeed * Time.deltaTime;
//			} else if (!rightObject) {//move to the right if no obstacle
//				Debug.Log("hit right");
//				ghostTransform.position += ghostTransform.right * movementSpeed * Time.deltaTime;
//			} else if (!leftObject) {//move to the left if no obstacle
//				//ghostTransform.transform.Rotate (0, 90, 0);
//				Debug.Log("hit left");
//				ghostTransform.position += ghostTransform.TransformDirection(Vector3.left) * movementSpeed * Time.deltaTime;
//			} else {//turn around if blocked in all directions
//				Debug.Log("hit back");
//				ghostTransform.position += ghostTransform.TransformDirection(Vector3.back) * movementSpeed * Time.deltaTime;
//			}
//
//			break;
//		case "Pinky":
//			targetPoint = new Vector3((target.transform.position.x-1), 0, (target.transform.position.z-1)) - transform.position;
//			targetRotation = Quaternion.LookRotation (targetPoint);
//			ghostTransform.rotation = Quaternion.Slerp(ghostTransform.rotation, targetRotation, Time.deltaTime * 2.0f);
//			break;
//		default:
//			break;
//		}

		//move toward target
			
//			if (!forwardObject) {//move forward if no obstacle
//				ghostTransform.position += ghostTransform.forward * movementSpeed * Time.deltaTime;
//			} else if (!rightObject) {//move to the right if no obstacle
//				ghostTransform.position += ghostTransform.right * movementSpeed * Time.deltaTime;
//			} else if (!leftObject) {//move to the left if no obstacle
//				ghostTransform.transform.Rotate (0, 90, 0);
//				ghostTransform.position += ghostTransform.forward * movementSpeed * Time.deltaTime;
//			} else {//turn around if blocked in all directions
//				ghostTransform.transform.Rotate (0, 180, 0);
//				ghostTransform.position += ghostTransform.forward * movementSpeed * Time.deltaTime;
//			}
	}

	void OnTriggerEnter (Collider other)
	{
		if (DestroyPellet.superPowered == true && DestroyPellet.counter < 20) 
		{

			if (other.tag == "Player") 
			{
				myTransform.position = new Vector3 (-5, 1, 4);
			}
				
		}
	}
}
