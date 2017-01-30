using UnityEngine;
using System.Collections;

public class PlayerPosition : MonoBehaviour {


	public Transform playerPos;
	public int posX = 0;
	public int posY = 0;	//	z+1, x+1
	public static int color = 0;

	void Start () {
		
		if(playerPos == null){
			playerPos = transform;
		}

	}

	void OnGUI() {
//		GUI.Label(new Rect(10, 10, 100, 20), "X: " + posX + " Y: " + posY);
//		GUI.Label(new Rect(10, 30, 100, 20), "COLOR: " + color);
	}
		
	void Update () {
		
		if(playerPos != null){
		
			posX = Mathf.CeilToInt(playerPos.position.z - 0.5f) + 1;
			posY = Mathf.CeilToInt(playerPos.position.x - 0.5f) + 1;
			color = PathData.instance.color[posX-1, posY-1];

		}
	}
}
