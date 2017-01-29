using UnityEngine;
using System.Collections;

public class PathColor : MonoBehaviour {

	public Color startColor;
	public Color finishColor;
	public Material pathMat;

	private float rStep;
	private float gStep;
	private float bStep;
	private bool ready = false;

	void Start () {
		StartCoroutine("WaitForData");
	}

	public IEnumerator WaitForData(){

		while(PathData.instance == null || !PathData.instance.initialized){
			yield return null;
		}

		rStep = (finishColor.r - startColor.r) / System.Convert.ToSingle(PathData.instance.maxColor);
		gStep = (finishColor.g - startColor.g) / System.Convert.ToSingle(PathData.instance.maxColor);
		bStep = (finishColor.b - startColor.b) / System.Convert.ToSingle(PathData.instance.maxColor);

		ready = true;

	}

	void Update () {

		if(ready){
			pathMat.color = new Color(startColor.r + ( (PathData.instance.maxColor - PlayerPosition.color) * rStep ),
										startColor.g + ( (PathData.instance.maxColor - PlayerPosition.color) * gStep ),
										startColor.b + ( (PathData.instance.maxColor - PlayerPosition.color) * bStep ));
		}

	}

}
