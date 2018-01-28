using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicRythm : MonoBehaviour {

	public 		GameManager		gameManager		;
	public		GameObject		bouleDisco		;

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
		beatClock += 1.000f * Time.deltaTime;
		beatInput += 1.000f * Time.deltaTime;

		// Beat clock
		if (beatClock > beatInterval)
		{
			// print("BEAT!");
			// gameManager.DoScreenFlash(new Color(0.6f, 0, 0.6f));
			bouleDisco.GetComponent<BouleDisco>().BeatDisco();
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

	}

}
