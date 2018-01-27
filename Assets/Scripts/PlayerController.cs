using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public 	float		speed;
	private	float		localScaleX;
	public	Animator	characterAnimator;
	public 	Animation	walkAnimation;

	void Start () 
	{
		characterAnimator = gameObject.GetComponent<Animator>();
		localScaleX = transform.localScale.x;
	}
	
	void Update () 
	{
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
	

		/*
		// Movement
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(new Vector3 (1 * speed, 0, 0));
			transform.localScale = new Vector2(-localScaleX, transform.localScale.y);
			characterAnimator.SetBool("isWalkingRight?", true);
		} else {
			characterAnimator.SetBool("isWalkingRight?", false);
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(new Vector3 (-1 * speed, 0, 0));
			characterAnimator.SetBool("isWalkingLeft?", true);
			transform.localScale = new Vector2(localScaleX, transform.localScale.y);
		} else {
			characterAnimator.SetBool("isWalkingLeft?", false);
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(new Vector3 (0, 1 * speed * 0.75f, 0));
			characterAnimator.SetBool("isWalkingUp?", true);
		} else {
			characterAnimator.SetBool("isWalkingUp?", false);
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(new Vector3 (0, -1 * speed * 0.75f, 0));
			characterAnimator.SetBool("isWalkingDown?", true);
		} else {
			characterAnimator.SetBool("isWalkingDown?", false);
		}

		// Animation

		*/

	}

}
