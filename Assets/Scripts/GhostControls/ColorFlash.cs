using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFlash : MonoBehaviour {
	//define starting color for ghosts
	public Color ColorStart = Color.blue;


	//define ending color for lerp flash
	public Color colorEnd = Color.white;

	public float duration = 1.0F;
	public Renderer rend;


	void Start() {
		rend = GetComponent<Renderer>();
	}
	void Update() {
		
		if (DestroyPellet.superPowered == true && DestroyPellet.counter < 20)
		{
			float lerp = Mathf.PingPong (Time.time, duration) / duration;
			rend.material.color = Color.Lerp (ColorStart, colorEnd, lerp);
			}
	}
}