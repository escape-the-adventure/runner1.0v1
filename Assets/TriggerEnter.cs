using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnter : MonoBehaviour {

	public GameObject gate;

	private void OnTriggerStay()
	{
//		gate.SetActive (false);
		gate.transform.position += gate.transform.up * Time.deltaTime * 5;
	}

}
