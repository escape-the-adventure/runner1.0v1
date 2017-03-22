using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour {

	public static InterfaceController instance;

	public GameObject swipe;
	public GameObject steeringBtns;
	public GameObject startBtn;
	public Text steeringName;
	public GameObject winScreen;
	public GameObject loseScreen;

	public int steering = 0;	//	0 - SWIPE ; 1 - BTNS	//	SWIPE steering details in SwipeController.cs

	private bool win;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		steering = PlayerPrefs.GetInt("steering", 0);
		SetSteering();
	}

	public void GameOver(){
		win = false;
		StartCoroutine("ShowResults");
		Animator2.instance.Death();
	}

	public void Win(){
		win = false;
		StartCoroutine("ShowResults");
		Animator2.instance.Idle();
	}

	IEnumerator ShowResults(){
		yield return new WaitForSeconds(1f);
		if(win){
			winScreen.SetActive(true);
		}
		else{
			loseScreen.SetActive(true);
		}
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
