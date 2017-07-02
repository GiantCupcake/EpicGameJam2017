﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour {
	//Ground
	public GameObject groundCube;
	public GameObject undergroundCube;
	//Buildings
	public GameObject firePit;
	public GameObject berlinWall;
	public GameObject brasserie;
	public GameObject loo;
	public GameObject windMill;
	//NPC
	public GameObject double_sirene;
	public GameObject witch;
	//Deco
	public Sprite arbreRadioactif;
	public Sprite barilNucleaire;
	public GameObject corn_deco;
	public GameObject flower_red;
	public GameObject flower_violet;
	public Sprite flower_white;
	public Sprite sapin_radioactif;

	public Sprite[] groundSprites;
	public Sprite[] buissonSprites;
	public Sprite[] cloudSprites;
	
	// Use this for initialization
	void Start ()
	{
		Texture2D mapPng = Resources.Load ("map") as Texture2D;
		Color32[] pix = mapPng.GetPixels32();
		Color32 groundColor = new Color32 (41, 23, 23, 255);
		Color32 fireColor = new Color32 (255, 3, 2, 255);
		Color32 emptyColor = new Color32 (0, 0, 0, 255);
		Color32 berlinWallColor = new Color32 (255, 127, 10, 255);
		Color32 looColor = new Color32 (0, 255, 0, 255);
		Color32 brasserieColor = new Color32 (0, 0, 255, 255);
		Color32 windMillColor = new Color32 (0, 255, 255, 255);
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
					pos.y -= 0.3f;
					currCube = Instantiate (firePit, pos, Quaternion.identity);
				} else if (pix [x + y * maxX].Equals (berlinWallColor)) {
					currCube = Instantiate (berlinWall, pos, Quaternion.identity);
				} else if (pix [x + y * maxX].Equals (looColor)){
					pos.y += 0.5f;
					currCube = Instantiate (loo, pos, Quaternion.identity);
				} else if (pix [x + y * maxX].Equals (brasserieColor)){
					pos.y -= 0.5f;
					currCube = Instantiate (brasserie, pos, Quaternion.identity);
				} else if (pix [x + y * maxX].Equals (windMillColor)){
					pos.y += 3.2f;
					currCube = Instantiate (windMill, pos, Quaternion.identity);
				} else if (!pix [x + y * maxX].Equals (emptyColor)) {
					Debug.Log (pix [x + y * maxX]);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
