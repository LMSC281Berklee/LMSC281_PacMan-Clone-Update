using UnityEngine;
using System.Collections;
using UnityEngine.AI;
public class Clyde : MonoBehaviour
{
		Transform player;                      
		NavMeshAgent nav; 
	Transform clyde;
	public Rigidbody rb;
	public GameObject clydee;
	public GameObject playerr;
	float dist;


		void Start ()
		{
		
		//NavMeshAgent = clydee;
			// Set up the references.
			player = GameObject.FindGameObjectWithTag ("Player").transform;
			nav = GetComponent <NavMeshAgent> ();
		nav.SetDestination (player.transform.position);
		clyde = clydee.transform;
		 dist = Vector3.Distance (player.position, clyde.position);
		}


		void Update ()
		{
		


		//*if ( dist <100) {nav.SetDestination (player.position);
		//}
		//	else
		//	{
				// ... disable the nav mesh agent.
		//		nav.enabled = false;
		}
		} 
	