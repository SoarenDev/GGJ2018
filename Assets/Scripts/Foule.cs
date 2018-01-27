using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Foule : MonoBehaviour {

	public Dancer d;

	public GameObject Moogle;
	public Transform foule;

	private int nbDancer = 1;
	private float posX;
	private float posY;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.Space))
			SpawnDancer ();
	}

	private void generateSpawnPosition () {
		posX = Random.Range(foule.position.x - (foule.GetComponent<CircleCollider2D>().radius * 5), foule.position.x + (foule.GetComponent<CircleCollider2D>().radius * 5));
		posY = Random.Range(foule.position.y - (foule.GetComponent<CircleCollider2D>().radius * 5), foule.position.y + (foule.GetComponent<CircleCollider2D>().radius * 5));
	
		//min -> posFoule + espace des dancers autour
		//max -> posFoule max + espace des dancers autour


	}



	private void SpawnDancer () {
		nbDancer++;
		generateSpawnPosition ();
		GameObject dancerSpawned = Instantiate (Moogle, new Vector2(posX, posY), foule.rotation);
		d = dancerSpawned.GetComponent<Dancer> ();
		//d.foule = this;
	}
}