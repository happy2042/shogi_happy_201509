using UnityEngine;
using System.Collections;

public class ActiveMove : MonoBehaviour {
	
	public long localPosX;
	public long localPosY;

	private GameObject _parent;
	private KomaInformation parentInfo;

	// Use this for initialization
	void Start () {
		_parent = transform.root.gameObject;
		localPosX = 0;
		localPosY = -1;
		Position ();
	}

	public void Position(){
		RectTransform rect = this.GetComponent<RectTransform>();
		rect.localPosition = new Vector3(PosX(localPosX), PosY(localPosY), 0f);
	}

	// クリック時の処理
	public void OnClick(){
		ParentMove ();
	}

	// 駒の移動
	void ParentMove(){
		parentInfo = GetComponentInParent<KomaInformation>();
		parentInfo.posx += localPosX;
		parentInfo.posy += localPosY;
		parentInfo.MyPosition ();
		Destroy (this.gameObject);
	}

	public float PosX(long x){
		float rectX = 60 * x;
		return rectX;
	}
	
	public float PosY(long y){
		float rectY = 64 * y * (-1);
		return rectY;
	}
}
