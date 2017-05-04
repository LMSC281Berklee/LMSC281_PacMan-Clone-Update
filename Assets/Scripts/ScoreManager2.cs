using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager2 : MonoBehaviour
{
	public static int score;


	GUIText text;


	void Awake ()
	{
		text = GetComponent <GUIText> ();
		score = 0;
	}


	void Update ()
	{
		text.text = "Score: " + score;
	}
}


	

