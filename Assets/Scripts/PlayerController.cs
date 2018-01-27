using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public	GameManager			gameManager			;

	public	Sprite				danceGauche_sprite	;
	public	Sprite				danceHaut_sprite	;
	public	Sprite				danceDroite_sprite	;

	public	List<DanceMovement>	danceMovementsList	;
	public	DanceMovement		activeDanceMovement	;

	public	Animator			characterAnimator	;
	public 	Animation			walkAnimation		;

	public 	float				speed				;
	public	bool				isMovementOn		 = true;
	private	float				localScaleX			;

	void Start () 
	{
		characterAnimator = gameObject.GetComponent<Animator>();
		localScaleX = transform.localScale.x;
		gameManager = Camera.main.GetComponent<GameManager>();
	}
	
	void Update () 
	{
		if (isMovementOn == true)
		{
		// | = = = MOVEMENT = = = |
			// MOVEMENT WITH AXIS
			if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
			{
				transform.Translate(new Vector3 (Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed * 0.70f, 0));
			}

			// ANIMATION
			if (Input.GetAxis("Horizontal") > 0)
			{
				transform.localScale = new Vector2(-localScaleX, transform.localScale.y);
				characterAnimator.SetBool("isWalkingRight?", true);
			} else {
				characterAnimator.SetBool("isWalkingRight?", false);
			}
			if (Input.GetAxis("Horizontal") < 0)
			{
				transform.localScale = new Vector2(localScaleX, transform.localScale.y);
				characterAnimator.SetBool("isWalkingLeft?", true);
			} else {
				characterAnimator.SetBool("isWalkingLeft?", false);
			}
			if (Input.GetAxis("Vertical") > 0)
			{
				characterAnimator.SetBool("isWalkingUp?", true);
			} else {
				characterAnimator.SetBool("isWalkingUp?", false);
			}
			if (Input.GetAxis("Vertical") < 0)
			{
				characterAnimator.SetBool("isWalkingDown?", true);
			} else {
				characterAnimator.SetBool("isWalkingDown?", false);
			}
		}
	
		// DANCE INPUTS
		if (Input.GetKeyDown("joystick button 1") == true)
		{
			BlockMovement();

			activeDanceMovement = gameManager.danceMovements_library[2];
			characterAnimator.SetBool("isDanceUp?", true);
			characterAnimator.SetBool("isDanceLeft?", false);
			characterAnimator.SetBool("isDanceRight?", false);
			print("Dance input 1");
		}
		if (Input.GetKeyDown("joystick button 2") == true)
		{
			BlockMovement();

			activeDanceMovement = gameManager.danceMovements_library[0];
			characterAnimator.SetBool("isDanceLeft?", true);
			characterAnimator.SetBool("isDanceRight?", false);
			characterAnimator.SetBool("isDanceUp?", false);
			print("Dance input 2");
		}
		if (Input.GetKeyDown("joystick button 3") == true)
		{	
			BlockMovement();

			activeDanceMovement = gameManager.danceMovements_library[1];
			characterAnimator.SetBool("isDanceRight?", true);
			characterAnimator.SetBool("isDanceLeft?", false);
			characterAnimator.SetBool("isDanceUp?", false);
			print("Dance input 3");
		}

		// CHECK INPUT PAR RAPPORT AU BEAT
		if (Input.GetKeyDown("joystick button 0") == true)
		{
			// print("INPUT");
			// print("Décalage : " + (beatInput));
			if (Mathf.Abs(gameManager.rythmScript.beatInput) < gameManager.rythmScript.beatInterval * (gameManager.rythmScript.errorAccept/2))
			{
				// print("IsOk");
				gameManager.DoScreenFlash(new Color(0.8f, 0.1f, 0.8f));
			} 
			else if (Mathf.Abs(gameManager.rythmScript.beatInput) < gameManager.rythmScript.beatInterval * gameManager.rythmScript.errorAccept)
			{
				// print("IsOk");
				gameManager.DoScreenFlash(new Color(0, 0, 0.8f));
			}
			else
			{
				gameManager.DoScreenFlash(new Color(0.8f, 0, 0));
			}

			// DEBUG
			characterAnimator.SetBool("isDanceLeft?", false);
			characterAnimator.SetBool("isDanceRight?", false);
			characterAnimator.SetBool("isDanceUp?", false);
			ReleaseMovement();

		}

		
	}

	public void BlockMovement()
	{
		isMovementOn = false;
		characterAnimator.SetBool("isWalkingLeft?", false);
		characterAnimator.SetBool("isWalkingUp?", false);
		characterAnimator.SetBool("isWalkingRight?", false);
	}

	public void ReleaseMovement()
	{
		isMovementOn = true;
	}

}
