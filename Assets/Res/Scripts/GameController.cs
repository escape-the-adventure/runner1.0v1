using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public static GameController instance;

	public GameObject mainCamera;
	public RayController rcWall;
	public RayController rcFinish;
	public bool checkRays = false;
	public bool canDie = true;

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

	void FixedUpdate(){
		if(checkRays && Generator.instance.initialized){
			if(!rcWall.collision && !rcFinish.collision && canDie){
				GameOver();
			}
			else if(rcFinish.collision){
				Win();
			}
		}
	}

	public void GameOver(){
		checkRays = false;
		mainCamera.transform.parent = null;
		InterfaceController.instance.GameOver();
	}

	public void Win(){
		checkRays = false;
		InterfaceController.instance.Win();
	}

}
