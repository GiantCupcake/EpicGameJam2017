using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : MonoBehaviour {
	Collider2D colider;
	// Use this for initialization
	void Start () {
		colider = this.GetComponent<Collider2D> ();
		colider.isTrigger = true;
		ContactFilter2D contactFilter = new ContactFilter2D();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("[Lootable] OnCollisionEnter2D");

		if (other.gameObject.tag == "Player") {
			Debug.Log ("Looted");
			Destroy (this.gameObject);
		}
	}
}
