//LMSC-281 Logic and Programming
//PacMan simple example, converted to C#
//from http://www.tosos.com/PacManClone.zip; found on http://forum.unity3d.com/threads/pac-man-clone-in-60-lines-of-code.56054/
//AI updates modified from the enemy movement tutorial here: http://www.palladiumgames.net/tutorials/beginning-unity-and-c-game-development/beginning-unity-and-c-part-11/
//by Jeanine Cowen - Spring 2017

using UnityEngine;
using System.Collections;

public class GhostControlTargets : MonoBehaviour {

	public Transform[] waypoints;
	int cur = 0;

	public float speed = 0.3f;

	void FixedUpdate ()
	{
		if (transform.position != waypoints [cur].position) {
			Vector2 p = Vector2.MoveTowards (transform.position, waypoints [cur].position, speed);
			GetComponent<Rigidbody> ().MovePosition (p);
		} 
		else cur = (cur + 1) % waypoints.Length;

		Vector2 dir = waypoints [cur].position - transform.position;
	}

	void OnTriggerEnter (Collider co) 
	{
		if (co.name == "PacMac")
			Destroy (co.gameObject);
	} 
}
