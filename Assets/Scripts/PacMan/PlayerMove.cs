//LMSC-281 Logic and Programming
//PacMan simple example, converted to C#
//from http://www.tosos.com/PacManClone.zip; found on http://forum.unity3d.com/threads/pac-man-clone-in-60-lines-of-code.56054/
//by Jeanine Cowen - Spring 2017

using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	//allow for editable movement values
	public float speed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;

	//a position holder
	private Vector3 moveDirection;

	//determine if the player is in collision state
	private CollisionFlags flags;

	//hold the collision state information
	private bool grounded  = false;
	
	void FixedUpdate() {
		if (grounded) {
			// We are grounded, so recalculate movedirection directly from axes
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			
			if (Input.GetButton ("Jump")) {
				moveDirection.y = jumpSpeed;
			}
		}
		
		// Apply gravity, to adjust for the jump functionality
		moveDirection.y -= gravity * Time.deltaTime;
		
		// Move the controller
		CharacterController controller = GetComponent<CharacterController>();
		flags = controller.Move(moveDirection * Time.deltaTime);
		grounded = (flags & CollisionFlags.CollidedBelow) != 0;
	}
}