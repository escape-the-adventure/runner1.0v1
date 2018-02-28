using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public static GameController instance;

	public GameObject mainCamera;
	public RayController[] rcWall;
	public RayController rcFinish;
	public bool checkRays = false;
	public bool canDie = true;
	public bool gameOver = false;

	void Awake(){
		instance = this;
	}

	void Start () {
		StartCoroutine("Wait");
	}

	IEnumerator Wait (){
		yield return new WaitForSeconds(1f);
		checkRays = true;
	}

	void Update(){
		if(checkRays && Generator.instance.initialized){
			if(!OnWall() && !rcFinish.collision && canDie){
				GameOver();
			}
			else if(rcFinish.collision){
				Win();
			}
		}
	}

	public void GameOver(){
		Debug.Log("GAME OVER");
		checkRays = false;
		mainCamera.transform.parent = null;
		InterfaceController.instance.GameOver();
		gameOver = true;
	}

	public void Win(){
		checkRays = false;
		InterfaceController.instance.Win();
	}

	public bool OnWall(){
		bool retVal = true;

		for(int i=0; i<rcWall.Length; i++){
			if(!rcWall[i].collision){
				retVal = false;
			}
		}

		return retVal;
	}



}
