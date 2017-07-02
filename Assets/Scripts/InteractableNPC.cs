using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class InteractableNPC : MonoBehaviour {

	GameObject dialogBand;
	List<string> dialogs = new List<string>();
	List<string>.Enumerator enumerator;
	public TextAsset dialogFile;

	public string npcName;

	public float roamDistance = 5f;
	public float speed = 1f;

	private bool moving;
	private float startingPos = 0f;
	private float goal;
	private Vector3 lastPos;
	private float pauseBeforeMoving;

	// Use this for initialization
	void Start () {
		parseTextAsset (dialogFile);

		dialogBand = GameObject.FindWithTag ("DialogBand");
		dialogBand.SetActive (false);

		enumerator = dialogs.GetEnumerator ();

		startingPos = transform.position.x;
		goal = startingPos + Random.Range(-(roamDistance), roamDistance);
		moveToGoal ();
	}

	void moveToGoal(){
		if (Mathf.RoundToInt(transform.position.x) == Mathf.RoundToInt(goal)) {
			moving = false;
			pauseBeforeMoving = Random.Range(0f, 3f) + Time.time;
		} else {
			moving = true;
			Vector3 dest = new Vector3 (goal, transform.position.y, transform.position.z);
			transform.position = Vector3.Lerp (transform.position, dest, Time.deltaTime);
			lastPos = transform.position;
		}
	}

	// Update is called once per frame
	void Update () {
		if (pauseBeforeMoving < Time.time) {
			if (!moving) {
				goal = startingPos + Random.Range (-(roamDistance), roamDistance);
			}
			moveToGoal ();
		}
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

	public void parseTextAsset (TextAsset ft ) {
		string fs = ft.text;
		//string[] fLines = Regex.Split (fs, "\n|\r|\r\n");
		string[] fLines = Regex.Split (fs, "\n");
		for (int i = 0; i < fLines.Length; i++) {
			Debug.Log (fLines [i]);
			dialogs.Add (fLines [i]);
		}
	}
}