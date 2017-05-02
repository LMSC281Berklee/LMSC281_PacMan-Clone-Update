using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class KillPac : MonoBehaviour
{
	private int pacLives = 3;

	public GUIText lifeText;
	public GameObject endScreen;

	void Awake()
	{
		lifeText.text = "Lives: " + pacLives;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Ghosty")) 
		{
			pacLives--;													// Decrement Life Count
			Time.timeScale = 0f; 										// Stops time so two collisions cannot happen before reset
			gameObject.transform.position = new Vector3 (0, 2, -6);
			Time.timeScale = 1f;										// Resumes time after player relocation

			lifeText.text = "Lives: " + pacLives;
		}
	}

	void Update()
	{
		if (pacLives <= 0) 
		{
			endScreen.SetActive (true);									// Activates End Screen object

			if (Input.GetKeyDown(KeyCode.Return)) 
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);		//Reloads Scene
			}
		}
	}
}
