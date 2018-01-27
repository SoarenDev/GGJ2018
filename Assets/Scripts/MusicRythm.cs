using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicRythm : MonoBehaviour {

	public 		GameManager		gameManager		;

	public		float			bpm				;

	public		float			beatOffset		;		// Décalage du premier beat (pour bien caler les deux)
	public		float			beatInterval	;		// Definit l'intervalle de temps entre deux Beats [en secondes]
	public		float			beatClock		;		// Compteur horloge définissant la position actuelle dans le beatInterval [en secondes]
	public 		float			beatInput		;		// Compteur horloge

[Tooltip("Définit le pourcentage de décalage autorisé pour l'input du joueur par rapport au beat. Valeur entre 0 et 1")]
	public		float			errorAccept		;

	void Start () 
	{
		beatInterval 	=	60.000f / bpm;
		beatClock		=	beatOffset;
	}
	
	void FixedUpdate()
	{
		// | = = = BEAT MANAGER = = = |

		// Incrémentation de du compteur horloge
		beatClock += 1.000f * Time.fixedDeltaTime;
		beatInput += 1.000f * Time.fixedDeltaTime;

		// Beat clock
		if (beatClock > beatInterval)
		{
			// print("BEAT!");
			// gameManager.DoScreenFlash(new Color(0.8f, 0.3f, 0.8f));
			beatClock	= 0f;
		}

		// Input offset clock
		if (beatInput > beatInterval * 0.5f)
		{
			// print("BEAT!");
			// gameManager.DoScreenFlash(new Color(0.8f, 0.3f, 0.8f));
			beatInput	= -beatInterval * 0.5f;
		}
	}

	void Update () 
	{
		
		// | = = = CHECK INPUT PAR RAPPORT AU BEAT = = = |

		if (Input.GetKeyDown("joystick button 0") == true)
		{
			// print("INPUT");
			// print("Décalage : " + (beatInput));
			if (Mathf.Abs(beatInput) < beatInterval * (errorAccept/2))
			{
				// print("IsOk");
				gameManager.DoScreenFlash(new Color(0.8f, 0.1f, 0.8f));
			} 
			else if (Mathf.Abs(beatInput) < beatInterval * errorAccept)
			{
				// print("IsOk");
				gameManager.DoScreenFlash(new Color(0, 0, 0.8f));
			}
			else
			{
				gameManager.DoScreenFlash(new Color(0.8f, 0, 0));
			}
		}

	}

}
