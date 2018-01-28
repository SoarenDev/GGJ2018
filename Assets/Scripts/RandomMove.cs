using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour {

	public GameObject PNJs;
	private Vector2 movement;

	private float dirX;
	private float dirY;

	[SerializeField]
	private float	speed;
	[SerializeField]
	private float intervalle;

	private float resetTime;
	private float timeLeft; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		timeLeft -= Time.deltaTime;

		if (timeLeft <= 0) {
			dirX = Random.Range (-0.1f * speed, 0.1f * speed);
			dirY = Random.Range (-0.1f * speed, 0.1f * speed); 
			resetTime = Random.Range (intervalle, intervalle * 1.5f );
			//reset de la valeur du tps
			timeLeft += resetTime;
			//reset du tps 
		}
			else {
			transform.Translate (new Vector2(dirX,dirY));
			//on bouge
		}
	}
	void OnColliderEnter2D(Collider2D col){
		if(col.gameObject.tag == "Mur"){
			dirX = -dirX;
			dirY = -dirY; 
			resetTime = Random.Range (intervalle, intervalle * 1.5f );
			//reset de la valeur du tps
			timeLeft += resetTime;
			//reset du tps 
		}
	}
}

