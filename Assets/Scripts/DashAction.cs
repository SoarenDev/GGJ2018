using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAction : MonoBehaviour {

	public	PlayerController	playerController	;

	public	DashComponent		activeDash			;

	public GameManager 			GameManager			;
	public Foule 				foule				;

	public	bool				isDashActive		;

	public	float				base_power			;
	public	float				base_speed			;
	public	float				base_range			;

	public	float				dashClock			;

	void Start () 
	{
		playerController = gameObject.GetComponent<PlayerController>();
	}
	
	void Update () 
	{
		if (isDashActive)
		{
			float	dash_duration = activeDash.dash_range / activeDash.dash_speed;
			if (dashClock < (dash_duration))
			{
				gameObject.transform.Translate(new Vector2 ((activeDash.dash_range / dash_duration) * activeDash.dash_direction.x, (activeDash.dash_range / dash_duration) * activeDash.dash_direction.y));
				dashClock += 1;
			} 
			else
			{
				FinishDash();
			}

			
		} // fin isDashActive
	} // fin update

	public void ConstructDash(float multiplicator)
	{
		DashComponent newDash = new DashComponent();

		// Definition valeurs base
		newDash.dash_power = base_power;
		newDash.dash_speed = base_speed;
		newDash.dash_range = base_range;

		// Calcul cumul valeurs mouvements composants
		for (int i = 0; i < playerController.danceMovementsList.Count; i++)
		{
			newDash.dash_power	+=	playerController.danceMovementsList[i].dance_power;
			newDash.dash_speed	+=	playerController.danceMovementsList[i].dance_speed;
			newDash.dash_range	+=	playerController.danceMovementsList[i].dance_range;
		}
		
		// Calcul de l'éventuel multiplicateur selon degré réussite (beat)
		newDash.dash_power	*=	multiplicator;
		newDash.dash_speed	*=	multiplicator;
		newDash.dash_range	*=	multiplicator;

		// Calcul du vecteur directeur
		// * 1 / Hori + verti
		float h_direction = Input.GetAxis("Horizontal");
		float v_direction = Input.GetAxis("Vertical");
		newDash.dash_direction = new Vector2 (h_direction * (1 / (Mathf.Abs(h_direction) + Mathf.Abs(v_direction))), v_direction * (1 / (Mathf.Abs(h_direction) + Mathf.Abs(v_direction))));
		if (newDash.dash_direction == new Vector2 (0,0))
		{
			newDash.dash_direction = new Vector2 (1, 0.01f);
		}

		// Transmission du composant Dash final
		activeDash = newDash;

		DoDash();
	}

	public void DoDash()
	{
		isDashActive = true;

		playerController.BlockMoveControl();
		playerController.BlockRegularInputs();
		print("DoDash");
	}

	public void FinishDash()
	{
		isDashActive = false;
		dashClock	= 0;

		playerController.ReleaseMoveControl();
		playerController.ReleaseRegularInputs();
		playerController.ClearDanceMovement();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "PNJ"){
			Debug.Log ("PNJ ");
			foule.SpawnDancer ();
			Destroy (col.gameObject);
		}
		if(col.gameObject.tag == "CRS"){
			Debug.Log ("CRS");
			GameManager.RemoveToPlayer (true, 3);
			//GameManager.StartMash ();
		}
	}
}
