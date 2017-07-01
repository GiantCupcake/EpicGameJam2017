using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMillBuilding : Building {

	public Sprite spritelvl1;
	public Sprite spritelvl2;
	public Sprite spritelvl3;
	public Sprite spritelvl4;

	private int currentLvl = 0;

	// Use this for initialization
	void Start () {
		listSprite.Add (spritelvl1);
		listSprite.Add (spritelvl2);
		listSprite.Add (spritelvl3);
		listSprite.Add (spritelvl4);

		enumerator = listSprite.GetEnumerator ();
		enumerator.MoveNext ();
		this.GetComponent<SpriteRenderer> ().sprite = enumerator.Current;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void UpgradeBuilding(){
		//On verifie dans l'inventaire que l'on a ce qu-il nous faut puis :
		enumerator.MoveNext ();
		this.GetComponent<SpriteRenderer> ().sprite = enumerator.Current;
	}
}
