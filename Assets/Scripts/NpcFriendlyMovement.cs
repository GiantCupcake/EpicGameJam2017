using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcFriendlyMovement : MonoBehaviour {

	public float roamDistance = 5f;
	public float speed = 1f;

	private float startingPos = 0f;
	private float goal;

	// Use this for initialization
	void Start () {
		startingPos = transform.position.x;

		goal = startingPos + Random.Range(-(roamDistance), roamDistance);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
