using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {

	public float spawnTime = 5f;
	public GameObject enemyType;
	public int enemyNumber = 1;
	private float lastSpawnTime;

	// Use this for initialization
	void Start () {
		lastSpawnTime = Time.fixedTime;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (spawnTime < Time.fixedTime - lastSpawnTime)
			spawnEnemy();
	}

	void spawnEnemy(){
		Instantiate (enemyType, transform.position, Quaternion.identity);
		lastSpawnTime = Time.fixedTime;
	}
}
