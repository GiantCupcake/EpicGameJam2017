using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerlinWallController : Building {

	public int maxHp = 500;
	private int currentHp;
	public bool underAttack = false;

	// Use this for initialization
	void Start () {
		currentHp = maxHp;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private bool isDead(){
		if (currentHp <= 0)
			return true;
		return false;
	}

	public void loseHp(int loss){
		currentHp -= loss;
		isDead ();
	}

	public void gainHp(int gain){
		currentHp += gain;
		if (currentHp > maxHp)
			currentHp = maxHp;
	}

	public int GetCurrentHp(){
		return currentHp;
	}
}