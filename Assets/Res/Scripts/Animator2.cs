using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator2 : MonoBehaviour {

	public static Animator2 instance;

	public Animator animator;
	public bool canStart = true;
	public Transform tr;

	Vector3 newRot = Vector3.zero;
	Quaternion currentRot;
	float currentLerp;

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
		StopCoroutine("GetStraight");
		StartCoroutine("GetStraight");
		animator.SetTrigger("TurnL");
	}

	public void TurnRight(){
		Debug.Log("[Animator2] Right");
		StopCoroutine("GetStraight");
		StartCoroutine("GetStraight");
		animator.SetTrigger("TurnR");
	}

	public void TurnAround() {
		Debug.Log ("[Animator2] TurnAround");
		StopCoroutine ("GetStraight");
		StartCoroutine ("GetStraight");
		animator.SetTrigger ("TurnA");
	}

	public void Idle(){
		Debug.Log("[Animator2] Idle");
		animator.SetTrigger("Idle");
	}

	public void Death(){
		Debug.Log("[Animator2] Death");
		animator.SetTrigger("Death");
	}

	IEnumerator GetStraight(){
		GameController.instance.canDie = false;
		yield return new WaitForSeconds(0.5f);
		GameController.instance.canDie = true;
		yield return new WaitForSeconds(0.25f);
//		yield return new WaitForSeconds(0.75f);
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

			currentRot = tr.rotation;
			currentLerp = 0f;

			for(int i=0; i<10; i++){
				tr.rotation = Quaternion.Lerp(currentRot, Quaternion.Euler(newRot), currentLerp);
				currentLerp += 0.1f;
				yield return new WaitForSeconds(0.1f);
			}
			tr.rotation = Quaternion.Euler(newRot);
		}
	}

}
