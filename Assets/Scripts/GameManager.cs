using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

[Space(10)][Header("Scripts binding")]
	public		GameManager			gameManager;

[Space(10)][Header("Objects bindings")]
	public		GameObject			player;
	public		GameObject			screenFlashPrefab;

[Space(10)][Header("Usual variable")]
	public		string				test;

[Space(10)][Header("References library")]
	public		List<DanceMovement>	danceMovements_library;

    void Awake() 
	{
        Application.targetFrameRate = 60;
    }

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		
	}

	void Update () 
	{
		
	}


	public void DoScreenFlash(Color flashColor)
	{
		GameObject instance;
		instance = Instantiate(screenFlashPrefab, new Vector2 (0,0), Quaternion.identity);
		instance.GetComponent<SpriteRenderer>().color = flashColor;
		Destroy(instance, 1);
	}

}
