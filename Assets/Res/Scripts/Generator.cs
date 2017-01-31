using UnityEngine;
using System.Collections;
using System;

public class Generator : MonoBehaviour {

	// Use this for initialization

	public static Generator instance;

	public GameObject[] wall;
	public GameObject floor;
	public GameObject player;
	public GameObject finish;
	public bool initialized = false;

	private int xSize = 0;
	private int ySize = 0;
	private int underPlayerWall = 1;

	void Awake(){
		instance = this;
	}

	void Start () {
		LoadData ();
	}

	void LoadData(){

		string filePath = "text/Stage1";
		//string tsv;
		string[] lines;
		TextAsset tsvText;
		GameObject tempObj = new GameObject();
		string currentToken;
		int currentWall;

		tsvText = Resources.Load(filePath) as TextAsset;
		lines = tsvText.text.Split('\n');

		ySize = lines.Length;

		for (int i = 1; i < lines.Length; i++) {
			string[] tokens = lines [i].Split ('\t');

			if (tokens.Length > xSize) {
				xSize = tokens.Length;
			}
		}

		floor.transform.localScale = new Vector3 (ySize, floor.transform.localScale.y, xSize);
		floor.transform.position = new Vector3 (ySize / 2f,	floor.transform.position.y, xSize / 2f);

		for (int i = 0; i < lines.Length; i++) {
			string[] tokens = lines [i].Split ('\t');

			for (int j = 0; j < tokens.Length; j++) {
				currentToken = tokens[j];
				if (currentToken == "s") {
					currentWall = underPlayerWall-1;
					tempObj = GameObject.Instantiate(wall[currentWall]) as GameObject;
					tempObj.transform.position = new Vector3 (i, tempObj.transform.position.y, j);
					tempObj = player;
				}
				else if (currentToken == "f") {
					tempObj = finish;
				}
				else if(tokens [j] == "p"){
					currentWall = underPlayerWall-1;
					tempObj = GameObject.Instantiate(wall[currentWall]) as GameObject;
				}
				else if(tokens [j] == ""){
					tempObj = null;
				}
				else if (Convert.ToInt32 (tokens [j]) > 0 && Convert.ToInt32 (tokens [j]) <= wall.Length) {
					currentWall = ((Convert.ToInt32 (tokens [j]))-1);
					tempObj = GameObject.Instantiate(wall[currentWall]) as GameObject;
				}
				else if(Convert.ToInt32 (tokens [j]) > 0){
					currentWall = wall.Length-1;
					tempObj = GameObject.Instantiate(wall[currentWall]) as GameObject;
				}
				else if(Convert.ToInt32 (tokens [j]) == 0){
					tempObj = null;
				}

				if(tempObj != null){
					tempObj.transform.position = new Vector3 (i, tempObj.transform.position.y, j);
				}
			}

		}
		initialized = true;
	}

}