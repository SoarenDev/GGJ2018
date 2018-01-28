using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

[Space(10)][Header("Scripts binding")]
	public	GameManager			gameManager			;
	public	DashAction			dashActionScript	;

[Space(10)][Header("Objects bindings")]
	public	List<DanceMovement>	danceMovementsList	;
	public	DanceMovement		activeDanceMovement	;

	public	List<GameObject> 	dancerList;

[Space(10)][Header("Usual variable")]
	public 	float				speed				;
	public	bool				isMovementOn		= true;
	public	bool				isRegularInputsOn	= true;
	public	bool				isInMashButton		= false;

	private	float				localScaleX			;


	void Start () 
	{
		gameManager = GameManager.instance;
		dashActionScript = gameObject.GetComponent<DashAction>();
		localScaleX = transform.localScale.x;
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
				for (int i = 0; i < dancerList.Count; i++) {
					dancerList[i].GetComponent<Animator>().SetBool("isWalkingRight?", true);
					dancerList[i].transform.localScale = new Vector2(-localScaleX, transform.localScale.y);
				}
			} else {
				for (int i = 0; i < dancerList.Count; i++) {
					dancerList[i].GetComponent<Animator>().SetBool("isWalkingRight?", false);
				}
			}
			if (Input.GetAxis("Horizontal") < 0)
			{
				for (int i = 0; i < dancerList.Count; i++) {
					dancerList [i].transform.localScale = new Vector2 (localScaleX, transform.localScale.y);
					dancerList [i].GetComponent<Animator> ().SetBool ("isWalkingLeft?", true);
				}
			} else {
				for (int i = 0; i < dancerList.Count; i++) {
					dancerList [i].GetComponent<Animator> ().SetBool ("isWalkingLeft?", false);
				}
			}
			if (Input.GetAxis("Vertical") > 0)
			{
				for (int i = 0; i < dancerList.Count; i++) {
					dancerList [i].GetComponent<Animator> ().SetBool ("isWalkingUp?", true);
				}
			} else {
				for (int i = 0; i < dancerList.Count; i++) {
					dancerList [i].GetComponent<Animator> ().SetBool ("isWalkingUp?", false);
				}
			}
			if (Input.GetAxis("Vertical") < 0)
			{
				for (int i = 0; i < dancerList.Count; i++) {
					dancerList [i].GetComponent<Animator> ().SetBool ("isWalkingDown?", true);
				}
			} else {
				for (int i = 0; i < dancerList.Count; i++) {
					dancerList [i].GetComponent<Animator> ().SetBool ("isWalkingDown?", false);
				}
			}

		}

		if (isRegularInputsOn == true)
		{
			// | === DANCE INPUTS === |

			if (Input.GetKeyDown("joystick button 3") == true)
			{
				// print("INPUT");
				// print("Décalage : " + (beatInput));

				// DECALAGE : PARFAIT
				if (Mathf.Abs(gameManager.rythmScript.beatInput) < gameManager.rythmScript.beatInterval * (gameManager.rythmScript.errorAccept/2))
				{
					// gameManager.DoScreenFlash(new Color(0.8f, 0.1f, 0.8f));
					DoDanceUp();
				} 
				// DECALAGE : OK
				else if (Mathf.Abs(gameManager.rythmScript.beatInput) < gameManager.rythmScript.beatInterval * gameManager.rythmScript.errorAccept)
				{
					// gameManager.DoScreenFlash(new Color(0, 0, 0.8f));
					DoDanceUp();
				}
				// DECALAGE : RATÉ
				else
				{
					gameManager.DoScreenFlash(new Color(0.8f, 0, 0));
					ClearDanceMovement();
				}

			}

			if (Input.GetKeyDown("joystick button 2") == true)
			{
				// DECALAGE : PARFAIT
				if (Mathf.Abs(gameManager.rythmScript.beatInput) < gameManager.rythmScript.beatInterval * (gameManager.rythmScript.errorAccept/2))
				{
					// gameManager.DoScreenFlash(new Color(0.8f, 0.1f, 0.8f));
					DoDanceLeft();
				} 
				// DECALAGE : OK
				else if (Mathf.Abs(gameManager.rythmScript.beatInput) < gameManager.rythmScript.beatInterval * gameManager.rythmScript.errorAccept)
				{
					// gameManager.DoScreenFlash(new Color(0, 0, 0.8f));
					DoDanceLeft();
				}
				// DECALAGE : RATÉ
				else
				{
					gameManager.DoScreenFlash(new Color(0.8f, 0, 0));
					ClearDanceMovement();
				}
			}


			if (Input.GetKeyDown("joystick button 1") == true)
			{	
				// DECALAGE : PARFAIT
				if (Mathf.Abs(gameManager.rythmScript.beatInput) < gameManager.rythmScript.beatInterval * (gameManager.rythmScript.errorAccept/2))
				{
					// gameManager.DoScreenFlash(new Color(0.8f, 0.1f, 0.8f));
					DoDanceRight();
				} 
				// DECALAGE : OK
				else if (Mathf.Abs(gameManager.rythmScript.beatInput) < gameManager.rythmScript.beatInterval * gameManager.rythmScript.errorAccept)
				{
					// gameManager.DoScreenFlash(new Color(0, 0, 0.8f));
					DoDanceRight();
				}
				// DECALAGE : RATÉ
				else
				{
					gameManager.DoScreenFlash(new Color(0.8f, 0, 0));
					ClearDanceMovement();
				}
			}

		// | === FIN DANCE INPUTS === |

			if (Input.GetKeyDown("joystick button 5") == true)
			{

				if (danceMovementsList.Count >= 2 && danceMovementsList.Count <= 10)
				{
					// DECALAGE : PARFAIT
					if (Mathf.Abs(gameManager.rythmScript.beatInput) < gameManager.rythmScript.beatInterval * (gameManager.rythmScript.errorAccept/2))
					{
						// gameManager.DoScreenFlash(new Color(0.8f, 0.1f, 0.8f));
						dashActionScript.ConstructDash(1.2f);
					} 
					// DECALAGE : OK
					else if (Mathf.Abs(gameManager.rythmScript.beatInput) < gameManager.rythmScript.beatInterval * gameManager.rythmScript.errorAccept)
					{
						// gameManager.DoScreenFlash(new Color(0, 0, 0.8f));
						dashActionScript.ConstructDash(1f);
					}
					// DECALAGE : RATÉ
					else
					{
						gameManager.DoScreenFlash(new Color(0.8f, 0, 0));
						ClearDanceMovement();
					}
				} else {
					print("Nombre de mouvements de dance invalide");
					ClearDanceMovement();
				}
			}

			if (Input.GetKeyDown(KeyCode.Escape))
			{
				// DEBUG
				for (int i = 0; i < dancerList.Count; i++) {
					dancerList [i].GetComponent<Animator> ().SetBool ("isDanceLeft?", false);
					dancerList [i].GetComponent<Animator> ().SetBool ("isDanceRight?", false);
					dancerList [i].GetComponent<Animator> ().SetBool ("isDanceUp?", false);
				}
				ClearDanceMovement();
			}

		} // Fin regular input IF

	} // Fin update

	public void BlockMoveControl()
	{
		isMovementOn = false;
		for (int i = 0; i < dancerList.Count; i++) {
			dancerList [i].GetComponent<Animator> ().SetBool ("isWalkingLeft?", false);
			dancerList [i].GetComponent<Animator> ().SetBool ("isWalkingUp?", false);
			dancerList [i].GetComponent<Animator> ().SetBool ("isWalkingRight?", false);
		}
	}

	public void ReleaseMoveControl()
	{
		isMovementOn = true;
	}

	public void BlockRegularInputs()
	{
		isRegularInputsOn = false;
		
		for (int i = 0; i < dancerList.Count; i++) {
			dancerList [i].GetComponent<Animator> ().SetBool ("isDanceLeft?", false);
			dancerList [i].GetComponent<Animator> ().SetBool ("isDanceUp?", false);
			dancerList [i].GetComponent<Animator> ().SetBool ("isDanceRight?", false);
		}
	}

	public void ReleaseRegularInputs()
	{
		isRegularInputsOn = true;
	}

	public void EnterMashupState()
	{
		isInMashButton = true;

		BlockMoveControl();
		BlockRegularInputs();
	}

	public void QuitMashupState()
	{
		isInMashButton = false;

		ReleaseMoveControl();
		ReleaseRegularInputs();
	}

	public void AddDanceMovement()
	{
		danceMovementsList.Add(activeDanceMovement);
	}

	public void	ClearDanceMovement()
	{
		int countToClear = danceMovementsList.Count;
		for (int i = 0; i < countToClear; i++)
		{
			danceMovementsList.Remove(danceMovementsList[0]);
		}

		for (int i = 0; i < dancerList.Count; i++) {
			dancerList [i].GetComponent<Animator> ().SetBool ("isDanceUp?", false);
			dancerList [i].GetComponent<Animator> ().SetBool ("isDanceLeft?", false);
			dancerList [i].GetComponent<Animator> ().SetBool ("isDanceRight?", false);
		}

		ReleaseMoveControl();
	}

	// DO DANCE

	private void	DoDanceLeft()
	{
		BlockMoveControl();

		activeDanceMovement = gameManager.danceMovements_library[2];
		for (int i = 0; i < dancerList.Count; i++) {
			dancerList [i].GetComponent<Animator> ().SetBool ("isDanceUp?", true);
			dancerList [i].GetComponent<Animator> ().SetBool ("isDanceLeft?", false);
			dancerList [i].GetComponent<Animator> ().SetBool ("isDanceRight?", false);
		}
		// print("Dance input 1");

		AddDanceMovement();
	}

	private void	DoDanceUp()
	{
		BlockMoveControl();

		activeDanceMovement = gameManager.danceMovements_library[0];
		for (int i = 0; i < dancerList.Count; i++) {
			dancerList [i].GetComponent<Animator> ().SetBool ("isDanceLeft?", true);
			dancerList [i].GetComponent<Animator> ().SetBool ("isDanceRight?", false);
			dancerList [i].GetComponent<Animator> ().SetBool ("isDanceUp?", false);
		}
		// print("Dance input 2");

		AddDanceMovement();
	}

	private void	DoDanceRight()
	{
		BlockMoveControl();

		activeDanceMovement = gameManager.danceMovements_library[1];
		for (int i = 0; i < dancerList.Count; i++) {
			dancerList [i].GetComponent<Animator> ().SetBool ("isDanceRight?", true);
			dancerList [i].GetComponent<Animator> ().SetBool ("isDanceLeft?", false);
			dancerList [i].GetComponent<Animator> ().SetBool ("isDanceUp?", false);
		}
			// print("Dance input 3");

		AddDanceMovement();
	}

}
