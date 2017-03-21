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

		if(Input.GetKeyDown(KeyCode.S)){
			TurnAround();
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

	public void TurnAround() {
		Debug.Log ("[Animator2] TurnAround");
		animator.SetTrigger ("TurnA");
		StopCoroutine ("GetStraight");
		StartCoroutine ("GetStrainght");
	}

	public void Idle(){
		Debug.Log("[Animator2] Idle");
		animator.SetTrigger("Idle");
	}

	IEnumerator GetStraight(){
		yield return new WaitForSeconds(0.75f);
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("run_cycle"))
		{
			Debug.Log("[Animator2] {GetStraight}");
			if(tr.rotation.eulerAngles.y < 100f && tr.rotation.eulerAngles.y > 80f){
				newRot = new Vector3(0f, 90f, 0f);
				Debug.Log("[Animator2] {GetStraight} 90");
			}
			else if(tr.rotation.eulerAngles.y < 190f && tr.rotation.eulerAngles.y > 170f){
				newRot = new Vector3(0f, 180f, 0f);
				Debug.Log("[Animator2] {GetStraight} 180");
			}
			else if(tr.rotation.eulerAngles.y < 280f && tr.rotation.eulerAngles.y > 260f){
				newRot = new Vector3(0f, 270f, 0f);
				Debug.Log("[Animator2] {GetStraight} 270");
			}
			else if(tr.rotation.eulerAngles.y < 10f || tr.rotation.eulerAngles.y > 350f){
				newRot = new Vector3(0f, 0f, 0f);
				Debug.Log("[Animator2] {GetStraight} 0");
			}
			tr.rotation = Quaternion.Euler(newRot);
		}
	}

}
