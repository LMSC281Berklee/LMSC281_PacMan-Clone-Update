using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFlash : MonoBehaviour {
	//define starting color for ghosts
	public static Color ColorStart = Color.blue;


	//define ending color for lerp flash
	public static Color colorEnd = Color.white;

	public static float duration = 1.0F;
	public Renderer rend1;
	public Renderer rend2;
	public Renderer rend3;
	public Renderer rend4;

	public Renderer tempRend;


	void Start() {

		tempRend = this.GetComponent<Renderer>;
		rend1 = GameObject.Find("Blinky").GetComponent<Renderer>();
		rend2 = GameObject.Find("Inky").GetComponent<Renderer>();
		rend3 = GameObject.Find("Pinky").GetComponent<Renderer>();
		rend4 = GameObject.Find("Clyde").GetComponent<Renderer>();

	}
	void Update() {
		if (DestroyPellet.superPowered = false) {

			this.material.color.GetComponent<Renderer>() = tempRend;

//			rend1.material.color = new Color (255, 0, 28, 191);
//
//			rend2.material.color = new Color (69, 231, 255, 199);
//
//			rend3.material.color = new Color (255, 126, 212, 225);
//
//			rend4.material.color = new Color (186, 145, 62, 213);
		}

		if (DestroyPellet.counter > 0) {
			
			if (DestroyPellet.superPowered == true && DestroyPellet.counter < 20) {
				float lerp = Mathf.PingPong (Time.time, duration) / duration;
				rend1.material.color = Color.Lerp (ColorStart, colorEnd, lerp);

				rend2.material.color = Color.Lerp (ColorStart, colorEnd, lerp);

				rend3.material.color = Color.Lerp (ColorStart, colorEnd, lerp);

				rend4.material.color = Color.Lerp (ColorStart, colorEnd, lerp);

		}


		}



	}

	
}