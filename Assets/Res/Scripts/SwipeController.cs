using UnityEngine;
using System.Collections;

public class SwipeController : MonoBehaviour {

	bool click = false;

	float startX = 0f;
	float startY = 0f;
	float endX = 0f;
	float endY = 0f;

	float deadZoneX = 0.1f;
	float deadZoneY = 0.1f;

	bool mouseDown = false;

	// Use this for initialization
	void Start () {
		
	}

	void Update() {
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
			mouseDown = true;
			startX = Input.GetTouch(0).position.x;
			startY = Input.GetTouch(0).position.y;
		}
		else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
			mouseDown = false;
			endX = Input.GetTouch(0).position.x;
			endY = Input.GetTouch(0).position.y;

			ScreenPart(endX, endY);
		}
	}

	void OnMouseDown() {
		mouseDown = true;
		startX = Input.mousePosition.x;
		startY = Input.mousePosition.y;
	}

	void OnMouseUp() {
		mouseDown = false;
		endX = (Input.mousePosition.x - startX) / Screen.width;
		endY = (Input.mousePosition.y - startY) / Screen.height;

		ScreenPart(endX, endY);
	}

	public void ScreenPart(float posX, float posY){
		int dirX = CheckX (posX);
		int dirY = CheckY (posY);

		if (dirX == -1 && dirY == 1) {
			Debug.Log ("[MouseController] Part : TL");
		}
		else if (dirX == 0 && dirY == 1) {
			Debug.Log ("[MouseController] Part : TM");
			Animator2.instance.MoveForward();
		}
		else if (dirX == 1 && dirY == 1) {
			Debug.Log ("[MouseController] Part : TR");
		}
		else if (dirX == -1 && dirY == 0) {
			Debug.Log ("[MouseController] Part : ML");
			Animator2.instance.TurnLeft();
		}
		else if (dirX == 0 && dirY == 0) {
			Debug.Log ("[MouseController] Part : MM");
		}
		else if (dirX == 1 && dirY == 0) {
			Debug.Log ("[MouseController] Part : MR");
			Animator2.instance.TurnRight();
		}
		else if (dirX == -1 && dirY == -1) {
			Debug.Log ("[MouseController] Part : BL");
		}
		else if (dirX == 0 && dirY == -1) {
			Debug.Log ("[MouseController] Part : BM");
		}
		else if (dirX == 1 && dirY == -1) {
			Debug.Log ("[MouseController] Part : BR");
		}

	}

	public int CheckX(float posX){
		int retVal = 0;
		if (posX > deadZoneX) {		//	RIGHT
			retVal = 1;
		}
		else if (posX < -deadZoneX) {	//	LEFT
			retVal = -1;
		}
		else {	//	MID
			retVal = 0;
		}
		return retVal;
	}

	public int CheckY(float posY){
		int retVal = 0;
		if (posY > deadZoneY) { // TOP
			retVal = 1;
		}
		else if (posY < -deadZoneY) {	// BOT
			retVal = -1;
		}
		else {	//	MID
			retVal = 0;
		}
		return retVal;
	}
		
}
