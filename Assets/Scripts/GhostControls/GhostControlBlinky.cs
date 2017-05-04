//LMSC-281 Logic and Programming
//PacMan simple example, converted to C#
//from http://www.tosos.com/PacManClone.zip; found on http://forum.unity3d.com/threads/pac-man-clone-in-60-lines-of-code.56054/
//by Jeanine Cowen - Spring 2017

using UnityEngine;
using System.Collections;

public class GhostControlBlinky : MonoBehaviour {
	
	Transform playerTransform;
	UnityEngine.AI.NavMeshAgent nav;

	void Awake ()
	{
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
	}
		

	void Update () 
	{
		nav.SetDestination (playerTransform.position);
	}
}
