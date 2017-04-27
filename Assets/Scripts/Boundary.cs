//LMSC-281 Logic and Programming
//PacMan simple example, converted to C#
//from http://www.tosos.com/PacManClone.zip; found on http://forum.unity3d.com/threads/pac-man-clone-in-60-lines-of-code.56054/
//by Jeanine Cowen - Spring 2017

using UnityEngine;
using System.Collections;
using System.Text;

public class Boundary : MonoBehaviour {

	public TextAsset mapAsset; //holds the reference to the map of the level
	public Transform blockPrefab; //holds the reference to the wall piece being generated
	public Transform pelletPrefab; //holds the reference to the normal pellet to be eaten by the player
	public Transform superPrefab; //holds the reference to the special pellet to be eaten by the player

	void Awake () {

		//read the map file into an array, each index is a separate line from the text file
		string[] map = mapAsset.text.Split ('\n');

		//setup the position of each map piece 
		Vector3 v = new Vector3 (0,0,0);

		//as a 2D game, the y position never changes
		v.y = 1.0f;

		//since the coordinate system has position 0,0 in the middle of the playing field, we need an offset to position correctly
		int i_off = map.Length / 2;

		//parse through the array line by line to find each individual character
		for (int i = 0; i < map.Length; i++) {

			//set the z position by referencing the line index of the array, includes an offset to adjust the coordinates
			v.z = (map.Length - i - i_off - 1) * 2;

			//create the offset for the x position
			int j_off = map[i].Length/2;

			//moving character by character, read in the playing field
			for (int j = 0; j < map[i].Length; j++) {

				//use the offset and the character position, to determine the prefab placement
				v.x = (j - j_off) * 2 + 1;

				//build the correct prefab according to the character type in the file
				if (map[i][j].Equals ('X')) {
					Instantiate(blockPrefab, v, Quaternion.identity);
				} else if (map[i][j].Equals ('.')) {
					Instantiate (pelletPrefab, v, Quaternion.identity);
				} else if (map[i][j].Equals ('O')) {
					Instantiate (superPrefab, v, Quaternion.identity);
				}
			}
		}
	}
}
