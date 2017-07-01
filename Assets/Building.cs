using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
		
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}


	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("[Building] OnCollisionEnter2D");

		if (other.gameObject.tag == "Player") {
			Debug.Log ("Entered Building CollideBox");
			Player player = other.gameObject.GetComponent<Player>();
			player.SetInteractableObject (this.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D other){
		Debug.Log ("[Building] OnCollisionExit2D");

		if (other.gameObject.tag == "Player") {
			Debug.Log ("Exited Building CollideBox");
			Player player = other.gameObject.GetComponent<Player>();
			player.ClearInteractableObject ();
		}
	}

	void UpgradeBuilding()
	{

	}

	void Interact()
	{
		Debug.Log ("[Building] Player Interacted");
	}

}
