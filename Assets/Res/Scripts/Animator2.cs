using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator2 : MonoBehaviour {

	public static Animator2 instance;

	public Animator animator;

	void Awake () {
		instance = this;
	}

	void Update () {

		if(Input.GetKeyDown(KeyCode.W)){
			MoveForward();
		}

		if(Input.GetKeyDown(KeyCode.A)){
			TurnLeft();
		}

		if(Input.GetKeyDown(KeyCode.D)){
			TurnRight();
		}

	}

	public void MoveForward(){
		Debug.Log("[Animator2] Forward");
		animator.SetTrigger("Forward");
	}

	public void TurnLeft(){
		Debug.Log("[Animator2] Left");
		animator.SetTrigger("TurnL");
	}

	public void TurnRight(){
		Debug.Log("[Animator2] Right");
		animator.SetTrigger("TurnR");
	}

}
