using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputController : MonoBehaviour {

	public enum State {Idle, Walk, WalkL, WalkR, Run, RunL, RunR};

	public State currentState = State.Idle;

	public Text inputXText;
	public Text inputYText;
	public Text speedText;

	public float posX;
	public float posY;

	public float directionX;
	public float directionY;

	public float currentSpeed;

	public Animator timAnim;

	public Transform tim;

	public Transform visualizer;

	public Transform directionTr;

	public float walkSpeed = 10f;
	public float runSpeed = 20f;
	public float walkTurnSpeed = 10f;
	public float runTurnSpeed = 20f;
	public float runStart = 0.8f;

	Vector2 inputVec;

	bool sprint = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		posX = Input.GetAxis ("Horizontal");
		posY = Input.GetAxis ("Vertical");

		if(inputXText){
			inputXText.text = "InputX: " + posX;
		}

		if(inputYText){
			inputYText.text = "InputY: " + posY;
		}

		directionTr.position = tim.position;
		directionTr.position = new Vector3 (directionTr.position.x + posX, directionTr.position.y, directionTr.position.z + posY);

		directionTr.parent = tim;

		inputVec = new Vector2 (posX, posY);

		if (inputVec.magnitude > 1f) {
			inputVec.Normalize ();
		}

		currentSpeed = inputVec.magnitude;
		currentSpeed = currentSpeed * 10f;
		currentSpeed = Mathf.Round(currentSpeed) / 10f;

		if(speedText){
			speedText.text = "Speed: " + currentSpeed;
		}

		if (visualizer) {
			visualizer.localPosition = new Vector3 (posX, posY, visualizer.localPosition.z);
		}

		directionX = directionTr.localPosition.x * 10f;
		directionX = Mathf.Round(directionX) / 10f;

		directionY = directionTr.localPosition.z * 10f;
		directionY = Mathf.Round(directionY) / 10f;


		if(currentSpeed > 0f){

			if (currentSpeed < runStart) {																		//	walk

				if(directionX < 0f || (directionX == 0f && directionY < 0f)) {
					if(currentState != State.WalkL){
						SetTrigger("walkL");
						currentState = State.WalkL;
					}
					tim.Rotate(-Vector3.up * walkTurnSpeed * Time.deltaTime);
					tim.position += tim.forward * walkSpeed * Time.deltaTime;
				}
				else if(directionX > 0f){
					if(currentState != State.WalkR){
						SetTrigger("walkR");
						currentState = State.WalkR;
					}
					tim.Rotate(Vector3.up * walkTurnSpeed * Time.deltaTime);
					tim.position += tim.forward * walkSpeed * Time.deltaTime;
				}
				else{
					if(currentState != State.Walk){
						SetTrigger("walk");
						currentState = State.Walk;
					}
					tim.position += tim.forward * walkSpeed * Time.deltaTime;
				}
			}
			else {																								//	run

				if(directionX < 0f || (directionX == 0f && directionY < 0f)) {
					if(currentState != State.RunL){
						SetTrigger("runL");
						currentState = State.RunL;
					}
					tim.Rotate(-Vector3.up * runTurnSpeed * Time.deltaTime);
					tim.position += tim.forward * runSpeed * Time.deltaTime;
				}
				else if(directionX > 0f){
					if(currentState != State.RunR){
						SetTrigger("runR");
						currentState = State.RunR;
					}
					tim.Rotate(Vector3.up * runTurnSpeed * Time.deltaTime);
					tim.position += tim.forward * runSpeed * Time.deltaTime;
				}
				else{
					if(currentState != State.Run){
						SetTrigger("run");
						currentState = State.Run;
					}
					tim.position += tim.forward * runSpeed * Time.deltaTime;
				}
				
			}

		}
		else{																									//	idle
			if(currentState != State.Idle){
				SetTrigger("idle");
				currentState = State.Idle;
			}
		}

	}

	public void SetTrigger(string triggerName){
		ResetTriggers();
		timAnim.SetTrigger(triggerName);
	}

	public void ResetTriggers(){
		timAnim.ResetTrigger("walk");
		timAnim.ResetTrigger("idle");
		timAnim.ResetTrigger("walkL");
		timAnim.ResetTrigger("walkR");
		timAnim.ResetTrigger("run");
		timAnim.ResetTrigger("runL");
		timAnim.ResetTrigger("runR");
	}



}
