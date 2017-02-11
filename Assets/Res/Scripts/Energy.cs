using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour {

	public static Energy instance;

	public int type = 0;	//	0 - time;	1 - distance;
	public float energy = 100f;
	public Slider slider;
	public bool loseEnergy = false;

	float startEnergy;

	// Use this for initialization
	void Awake () {
		instance = this;
		startEnergy = energy;
	}
	
	// Update is called once per frame
	void Update () {
		if(type == 0){
			LoseEnergy(Time.deltaTime);
		}
	}

	public void StartLoseEnergy(){
		loseEnergy = true;
	}

	public void LoseEnergy(float value){
		if(loseEnergy){
			energy -= value;
			slider.value = energy / startEnergy;
			if(energy <= 0f){
				InterfaceController.instance.GameOver();
			}
		}
	}


}
