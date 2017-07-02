using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float roamDistance = 5f;
	public float speed = 1f;

	private bool moving;
	private float startingPos = 0f;
	private float goal;
	private Vector3 lastPos;
	private float pauseBeforeMoving;
	private Rigidbody2D rb2D;
	private int jumpTimer;


	void moveToGoal(){
		moving = true;
		Vector3 dest = new Vector3 (transform.position.x + goal, transform.position.y, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, dest, Time.deltaTime * speed);
		lastPos = transform.position;
	}

	void jump(){
		rb2D.AddForce(new Vector2(0.5f, 230));
		jumpTimer = Mathf.RoundToInt(Time.time + Mathf.RoundToInt(Random.Range (2, 4)));
	}

	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < 0)
			goal = 1;
		else
			goal = -1;
		if (jumpTimer < Time.time)
			jump ();
		moveToGoal ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "BerlinWall") {
			speed = 0f;
		}
	}
}
