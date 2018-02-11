using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform destination;

    Vector3 position;
    Transform tr;

	// Use this for initialization
	void Start () {
        tr = transform;

        if (destination)
        {
            position = destination.position - tr.position;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (destination)
        {
            tr.position = destination.position - position;
        }
	}
}
