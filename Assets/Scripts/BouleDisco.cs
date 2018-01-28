using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BouleDisco : MonoBehaviour {

	public bool	isSprite1	= false;
	public	Sprite	sprite1;
	public	Sprite	sprite2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BeatDisco ()
	{
		isSprite1 = !isSprite1;

		if (isSprite1 == true)
		{
			gameObject.GetComponent<Image>().sprite = sprite1;
		}
		else 
		{
			gameObject.GetComponent<Image>().sprite = sprite2;
		}
			
	}

}


