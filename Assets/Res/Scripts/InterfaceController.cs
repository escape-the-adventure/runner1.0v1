using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour {

	public GameObject swipe;
	public GameObject steeringBtns;
	public GameObject startBtn;
	public Text steeringName;
	public GameObject winScreen;
	public GameObject loseScreen;

	public RayController rcWall;
	public RayController rcFinish;
	public bool checkRays = false;

	public int steering = 0;	//	0 - SWIPE ; 1 - BTNS	//	SWIPE steering details in SwipeController.cs

	// Use this for initialization
	void Start () {
		steering = PlayerPrefs.GetInt("steering", 0);
		SetSteering();
		StartCoroutine("Wait");
	}

	IEnumerator Wait (){
		yield return new WaitForSeconds(1f);
		checkRays = true;
	}

	void FixedUpdate(){
		if(checkRays && Generator.instance.initialized){
			if(!rcWall.collision && !rcFinish.collision){
				loseScreen.SetActive(true);
				ShowResults();
			}
			else if(rcFinish.collision){
				winScreen.SetActive(true);
				ShowResults();
			}
		}
	}

	void ShowResults(){
		checkRays = false;
		Animator2.instance.canStart = false;
		Animator2.instance.Idle();
	}

	public void SetSteering(){
		if(steering == 0){
			swipe.SetActive(true);
			steeringBtns.SetActive(false);
			steeringName.text = "SWIPE";
		}
		else{
			swipe.SetActive(false);
			steeringBtns.SetActive(true);
			steeringName.text = "BUTTONS";
		}
	}

	public void ChangeSteering(){
		if(steering == 0){
			steering = 1;
		}
		else{
			steering = 0;
		}
		PlayerPrefs.SetInt("steering", steering);
		SetSteering();
	}

	public void ButtonStart(){
		Animator2.instance.MoveForward();
		startBtn.SetActive(false);

	}

	public void ButtonRestart(){
		Application.LoadLevel(Application.loadedLevel);
	}


}
