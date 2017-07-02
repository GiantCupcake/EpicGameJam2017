using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour {
	public enum States {goalLess, moving, fleeing, attacking};
	public Vector2 currentGoal { get; set;}
	public States state { get; set;}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){

	}

	void OnCollisionEnter2D(Collision2D other){
		Debug.Log ("[NPCMovement] OnCollisionEnter2D");

		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Aggroable") {
			Player player = other.gameObject.GetComponent<Player> ();
			Debug.Log("Damaging the player");
			player.takeDamage (10);
		}
	}

	protected void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("[NPCMovement] OnTriggerEnter2D");

		if (other.gameObject.tag == "Player") {
			Player player = other.gameObject.GetComponent<Player>();
			player.takeDamage (10);
		}
	}

	/*
	protected void OnTriggerStay2D(Collider2D other){
		Debug.Log ("[NPCMovement] OnCollisionExit2D");

		if (other.gameObject.tag == "Player") {
			Player player = other.gameObject.GetComponent<Player>();
			player.ClearInteractableObject ();
		}
	}
	*/
		
}
