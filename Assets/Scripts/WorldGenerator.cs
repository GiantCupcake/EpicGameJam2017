using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour {

	public GameObject groundCube;
	public GameObject firePit;
	public GameObject undergroundCube;
	public GameObject berlinWall;
	public Sprite[] groundSprites;
	
	// Use this for initialization
	void Start ()
	{
		Texture2D mapPng = Resources.Load ("map") as Texture2D;
		Color32[] pix = mapPng.GetPixels32();
		Color32 groundColor = new Color32 (42, 24, 24, 255);
		Color32 fireColor = new Color32 (255, 0, 0, 255);
		Color32 emptyColor = new Color32 (0, 0, 0, 255);
		Color32 berlinWallColor = new Color32 (255, 128, 0, 255);
		int maxX = mapPng.width;
		int maxY = mapPng.height;
		int i = 0;
		int y2;
		Vector3 pos = new Vector3 (0, 0, 0);
		GameObject currCube;

		for (int y = 0; y < maxY; y++) {
			for (int x = 0; x < maxX; x++) {
				pos = new Vector3 (x, y - 32, 0);
				if (pix [x + y * maxX].Equals (groundColor)) {
					currCube = Instantiate (groundCube, pos, Quaternion.identity);
					currCube.GetComponent<SpriteRenderer> ().sprite = groundSprites [UnityEngine.Random.Range (0, groundSprites.Length)];
					y2 = y - 1;
					while (y2 >= 0) {
						pos = new Vector3 (x, y2 - 32, 0);
						currCube = Instantiate (undergroundCube, pos, Quaternion.identity);
						pix [x + y2 * maxY] = emptyColor;
						y2--;
					}
				} else if (pix [x + y * maxX].Equals (fireColor)) {
					currCube = Instantiate (firePit, pos, Quaternion.identity);
				} else if (pix [x + y * maxX].Equals (berlinWallColor)) {
					currCube = Instantiate (berlinWall, pos, Quaternion.identity);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
