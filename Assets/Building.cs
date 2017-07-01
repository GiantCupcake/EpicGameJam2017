using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
	protected List<Sprite> listSprite = new List<Sprite> ();
	protected List<Sprite>.Enumerator enumerator;
	void Start () {
		enumerator = listSprite.GetEnumerator ();
	}

	// Update is called once per frame
	void Update () {

	}


	protected void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("[Building] OnCollisionEnter2D");

		if (other.gameObject.tag == "Player") {
			Debug.Log ("Entered Building CollideBox");
			Player player = other.gameObject.GetComponent<Player>();
			player.SetInteractableObject (this.gameObject);
		}
	}

	protected void OnTriggerExit2D(Collider2D other){
		Debug.Log ("[Building] OnCollisionExit2D");

		if (other.gameObject.tag == "Player") {
			Debug.Log ("Exited Building CollideBox");
			Player player = other.gameObject.GetComponent<Player>();
			player.ClearInteractableObject ();
		}
	}

	protected void UpgradeBuilding()
	{

	}

	protected void Interact()
	{
		Debug.Log ("[Building] Player Interacted");
	}

}
