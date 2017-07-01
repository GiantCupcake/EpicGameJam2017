using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableNPC : MonoBehaviour {

	GameObject dialogBand;
	List<string> dialogs = new List<string>();
	List<string>.Enumerator enumerator;

	public string npcName;
	// Use this for initialization
	void Start () {
		dialogs.Add("Test Dialog N~1");
		dialogs.Add ("Test Dialog N~2");


		dialogBand = GameObject.FindWithTag ("DialogBand");
		dialogBand.SetActive (false);

		enumerator = dialogs.GetEnumerator ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("[NPCInteractable] OnCollisionEnter2D");

		if (other.gameObject.tag == "Player") {
			Debug.Log ("Entered NPC CollideBox");
			Player player = other.gameObject.GetComponent<Player>();
			player.SetInteractableObject (this.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D other){
		Debug.Log ("[NPCInteractable] OnCollisionExit2D");

		if (other.gameObject.tag == "Player") {
			Debug.Log ("Exited Building CollideBox");
			Player player = other.gameObject.GetComponent<Player>();
			player.ClearInteractableObject ();
			dialogBand.SetActive (false);
			enumerator = dialogs.GetEnumerator ();
		}
	}

	void Interact(){
		Debug.Log("[NPCInteractable] Interact");
		if (enumerator.MoveNext () == false) {
			dialogBand.SetActive (false);
			enumerator = dialogs.GetEnumerator ();
		} else {
			dialogBand.SetActive (true);
			dialogBand.GetComponentInChildren<UnityEngine.UI.Text> ().text = enumerator.Current;
		}
	}
}
