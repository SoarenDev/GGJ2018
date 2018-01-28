using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCRS : MonoBehaviour {
	public GameObject CRS;

	private float posX;
	private float posY;

	[SerializeField]
	private float X;
	[SerializeField]
	private float Y;

	private float resetTime;
	private float timeLeft;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;

		if (timeLeft <= 0) {
			resetTime = Random.Range (10f, 15f);
			timeLeft += resetTime; 
			Spawn ();
		}
	}
	private void SpawnPosition(){
		posX = Random.Range (-X, X);
		posY = Random.Range (-Y, Y);
	}

	private void Spawn(){
		SpawnPosition ();
		GameObject CRSpawned = Instantiate (CRS, new Vector3(posX, posY,0), Quaternion.identity);
	}
}

