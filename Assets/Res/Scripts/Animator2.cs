using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator2 : MonoBehaviour {

	public static Animator2 instance;

	public Animator animator;
	public bool canStart = true;
	public Transform tr;

	Vector3 newRot = Vector3.zero;

	void Awake () {
		instance = this;
		tr = transform;
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
		if(canStart){
			Debug.Log("[Animator2] Forward");
			animator.SetTrigger("Forward");
			Energy.instance.StartLoseEnergy();
		}
	}

	public void TurnLeft(){
		Debug.Log("[Animator2] Left");
		animator.SetTrigger("TurnL");
		StopCoroutine("GetStraight");
		StartCoroutine("GetStraight");
	}

	public void TurnRight(){
		Debug.Log("[Animator2] Right");
		animator.SetTrigger("TurnR");
		StopCoroutine("GetStraight");
		StartCoroutine("GetStraight");
	}

	public void Idle(){
		Debug.Log("[Animator2] Idle");
		animator.SetTrigger("Idle");
	}

	IEnumerator GetStraight(){
		yield return new WaitForSeconds(0.55f);
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("run_cycle"))
		{
			Debug.Log("[Animator2] {GetStraight}");
			if(tr.rotation.eulerAngles.y < 95f && tr.rotation.eulerAngles.y > 85f){
				newRot = new Vector3(0f, 90f, 0f);
				Debug.Log("[Animator2] {GetStraight} 90");
			}
			else if(tr.rotation.eulerAngles.y < 185f && tr.rotation.eulerAngles.y > 175f){
				newRot = new Vector3(0f, 180f, 0f);
				Debug.Log("[Animator2] {GetStraight} 180");
			}
			else if(tr.rotation.eulerAngles.y < 275f && tr.rotation.eulerAngles.y > 265f){
				newRot = new Vector3(0f, 270f, 0f);
				Debug.Log("[Animator2] {GetStraight} 270");
			}
			else if(tr.rotation.eulerAngles.y < 5f || tr.rotation.eulerAngles.y > 355f){
				newRot = new Vector3(0f, 0f, 0f);
				Debug.Log("[Animator2] {GetStraight} 0");
			}
			tr.rotation = Quaternion.Euler(newRot);
		}
	}

}
