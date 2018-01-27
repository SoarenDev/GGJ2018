using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

[Space(10)][Header("Scripts binding")]
	public		GameManager		gameManager;

[Space(10)][Header("Objects bindings")]
	public		GameObject		player;

[Space(10)][Header("Usual variable")]
	public		string			test;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
	

	void Update () {
		
	}
}
