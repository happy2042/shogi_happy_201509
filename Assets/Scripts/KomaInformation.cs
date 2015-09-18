using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class KomaInformation : MonoBehaviour {

	public string komaName;
	public long posx;
	public long posy;
	public long owner;
	public bool promote;

	public void MyPosition(){
		RectTransform rect = this.GetComponent<RectTransform>();
		rect.localPosition = new Vector3(CalcPosX(posx), CalcPosY(posy), 0f);
		/*
		if (owner != owner_id)
			rect.localRotation = Quaternion.AngleAxis (180, Vector3.z);
			*/
	}

	public float CalcPosX(long x){
		float rectX = 300 - 60 * x;
		return rectX;
	}

	public float CalcPosY(long y){
		float rectY = 320 - 64 * y;
		return rectY;
	}

	public void SpriteChanger(){
		Sprite spr = Resources.Load<Sprite>("Shogi_pictures/60x64/" + komaName);
		Image image = this.GetComponent<Image> ();
		image.overrideSprite = spr;
 	}
}
