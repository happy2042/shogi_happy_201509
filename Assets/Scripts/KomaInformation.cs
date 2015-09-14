using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KomaInformation : MonoBehaviour {

	//public string komaName;
	public long posx;
	public long posy;
	public long owner;
	public bool promote;

	public void MyPosition(){
		RectTransform rect = this.GetComponent<RectTransform>();
		rect.localPosition = new Vector3(CalcPosX(posx), CalcPosY(posy), 0f);
	}

	public float CalcPosX(long x){
		float rectX = 300 - 60 * x;
		return rectX;
	}

	public float CalcPosY(long y){
		float rectY = 320 - 64 * y;
		return rectY;
	}

}
