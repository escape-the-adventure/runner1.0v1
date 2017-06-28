using UnityEngine;
using System.Collections;

public class RayController : MonoBehaviour {

	public bool collision = false;
	public bool draw = false;
	public bool checkTag = false;
	public bool fromLocal = false;
	public bool autoCheck = true;
	public LayerMask layerMask;
	public float rayDistance;
	public float rayVectorX;
	public float rayVectorY;
	public string rayTag;

	private Transform tr;
	private GameObject go;
	private RaycastHit hit;
	private Vector3 rayVector;
	private Vector3 rayVector3;

	// Use this for initialization
	void Start () {
		tr = transform;
		go = gameObject;
		rayVector3 = new Vector3 (rayVectorX, rayVectorY, 0f);
	}
	
	// Update is called once per frame
	void Update () {

		if(autoCheck){
			collision = CheckHit ();
		}

	}

	public bool CheckHit(){

		if (fromLocal) {
			rayVector = new Vector3 (-tr.InverseTransformDirection (rayVector3).x, tr.InverseTransformDirection (rayVector3).y, 0f);
		} 
		else {
			rayVector = new Vector3 (rayVectorX, rayVectorY, 0f);
		}

		Physics.Raycast(tr.position, rayVector, out hit, rayDistance, layerMask.value);

		if (draw && Animator2.instance.canMove) {
			Debug.DrawRay (tr.position, rayVector * rayDistance, Color.red, 3f);
		}

		if (hit.collider != null) {
			
			if (checkTag) {
				
				if (hit.transform.tag == rayTag) {
					
					if (hit.transform.gameObject != go) {
						return true;
					} 
					else {
						return false;
					}

				} 
				else {
					return false;
				}

			} 
			else {

				if (hit.transform.gameObject != go) {
					return true;
				} 
				else {
					return false;
				}
					
			}

		}
		else {
			return false;
		}

	}

	public bool CheckHit(Transform newTr){
		tr = newTr;
		return (CheckHit());
	}

	void Log(string logText){
		Debug.Log ("[RayController] " + logText);
	}

}
