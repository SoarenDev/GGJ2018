using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MashButton : MonoBehaviour {

	public PlayerController PC;
	private int nbMash;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.RightAlt))
			KeyPressed ();
	}

	void KeyPressed (){
		nbMash++;
		//mouvement -> OFF

	}
}
