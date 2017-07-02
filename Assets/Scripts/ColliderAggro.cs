using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderAggro : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	protected void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log ("[ColliderAggro] OnTriggerEnter2D");

		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Aggroable") {
			//Debug.Log ("Entered Aggro CollideBox");
			//On veut qu'il suive la cible
			NPCMovement monsterController = this.GetComponentInParent<NPCMovement> ();
			Vector2 newTarget = other.transform.position;
			monsterController.currentGoal = newTarget;
			monsterController.state = NPCMovement.States.attacking;
		}
	}

	protected void OnTriggerExit2D(Collider2D other){
		//Debug.Log ("[ColliderAggro] OnCollisionExit2D");

		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Aggroable") {
			//Debug.Log ("Exited Aggro CollideBox");
			//On veut qu'il suive la cible
			NPCMovement monsterController = this.GetComponentInParent<NPCMovement> ();
			monsterController.state = NPCMovement.States.goalLess;
		}
	}

	protected void OnTriggerStay2D(Collider2D other){
		//Debug.Log ("[ColliderAggro] OnCollisionStay2D");

		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Aggroable") {
			//Debug.Log ("Stayed Aggro CollideBox");
			//On veut qu'il suive la cible
			NPCMovement monsterController = this.GetComponentInParent<NPCMovement> ();
			Vector2 newTarget = other.transform.position;
			monsterController.currentGoal = newTarget;
			monsterController.state = NPCMovement.States.attacking;
		}
	}
}
