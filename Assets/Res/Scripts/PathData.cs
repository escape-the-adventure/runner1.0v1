using UnityEngine;
using System.Collections;
using System;

public class PathData : MonoBehaviour {

	public static PathData instance;
	public bool initialized = false;
	public int[,] color;
	public int maxColor = 0;

	private int xSize = 0;
	private int ySize = 0;

	void Start () {
		instance = this;
		LoadData ();
	}

	void LoadData(){

		string filePath = "text/Stage1Color";
		string[] lines;
		TextAsset tsvText;
		string currentToken;

		tsvText = Resources.Load(filePath) as TextAsset;
		lines = tsvText.text.Split('\n');

		ySize = lines.Length;

		for (int i = 1; i < lines.Length; i++) {
			string[] tokens = lines [i].Split ('\t');

			if (tokens.Length > xSize) {
				xSize = tokens.Length;
			}
		}

		color = new int[xSize,ySize];
			

		for (int i = 0; i < lines.Length; i++) {
			string[] tokens = lines [i].Split ('\t');

			for (int j = 0; j < tokens.Length; j++) {
				currentToken = tokens[j];
				color[j,i] = System.Convert.ToInt32(currentToken);

				if(color[j,i] > maxColor){
					maxColor = color[j,i];
				}

			}

		}

		initialized = true;

	}

}