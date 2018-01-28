using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private 	bool 				isMashing;
	public 		float 				p1NbMash;
	public 		float 				p2NbMash;
	public 		float 				compteur;

	public static GameManager 		instance;

[Space(10)][Header("Scripts binding")]
	public		MusicRythm			rythmScript;
	public 		PlayerController 	p1PlayerController;
	public 		Foule 				p1Foule;
	public 		PlayerController 	p2PlayerController;
	public 		Foule 				p2Foule;

[Space(10)][Header("Objects bindings")]
	public		GameObject			player;
	public		GameObject			screenFlashPrefab;

[Space(10)][Header("Usual variable")]
	public		string				test;

[Space(10)][Header("References library")]
	public		List<DanceMovement>	danceMovements_library;


    void Awake() 
	{
		if (instance == null) {
			instance = this;
		} else {
			Destroy (this);
		}
        Application.targetFrameRate = 60;
    }

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		
	}

	void Update () 
	{
		if (isMashing == true)
			Mashing ();	
	}


	public void DoScreenFlash(Color flashColor)
	{
		GameObject instance;
		instance = Instantiate(screenFlashPrefab, new Vector2 (0,0), Quaternion.identity);
		instance.GetComponent<SpriteRenderer>().color = flashColor;
		Destroy(instance, 1);
	}

	public void RegisterToPlayer(bool firstPlayer, GameObject dancer)
	{
		if (firstPlayer) {
			p1PlayerController.dancerList.Add(dancer);

		} else {
			//p2PlayerController.dancerList.Add(dancer);

		}
	}

	public void Mashing(){
		compteur += 1;

							if (Input.GetKeyDown (KeyCode.RightAlt)){
			Debug.Log ("MASHED");
			p1NbMash += 1;
			}
	}
	public void StartMash(){
		isMashing = true;
		p1NbMash = p1Foule.nbDancer;
		//p2NbMash = p2Foule.nbDancer;

		//stoper les mouvements et animations
	}
	public void StopMash (){
		isMashing = false;
		compteur = 0;

		//free les mouvements et animations
	}

}
