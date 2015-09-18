using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class KomaGenerator : MonoBehaviour {

	string url = "http://192.168.3.83:3000/get_pieces.json";

	public GameObject koma;
	public GameObject parentObject;

	Wrapper wrapper;

	void Start(){
		wrapper = GameObject.Find("Wrapper").GetComponent<Wrapper>();
		parentObject = GameObject.Find ("board");

		KomaInfoGet ();
	}

	// 駒の情報を取得
	public void KomaInfoGet(){
		WWW www = wrapper.GET (url, SetKomaArrange);

	}

	public void SetKomaArrange(Dictionary<string,object> json) {
		Dictionary<string, object> info;
		for(int i = 0; i < 40; i++){
			info = (Dictionary<string,object>)json[(i+1).ToString()];
			// 生成
			KomaArrange(info);
		}
	}
	
	// 駒を生成する
	public void KomaArrange(Dictionary<string, object> komaInfo){
		// 駒のprefab情報を取得
		koma = (GameObject)Resources.Load ("Prefabs/koma");
		// 駒の情報をセット
		KomaInfoSet (komaInfo);

		// Canvasの子として生成する
		GameObject komaPrefab = (GameObject)Instantiate (koma);
		komaPrefab.transform.SetParent (parentObject.transform, false);

		// 駒の情報からスクリーン上の座標に変換
		komaPrefab.GetComponent<KomaInformation> ().MyPosition ();
		komaPrefab.GetComponent<KomaInformation> ().SpriteChanger ();
	}

	// 駒に取得した情報を投げる
	public void KomaInfoSet(Dictionary<string, object> komaInfo){
		var komaInfomation = koma.GetComponent<KomaInformation> ();

		//komaInfomation.komaName = (string)komaInfo["name"];
		komaInfomation.posx = (long)komaInfo["posx"];
		komaInfomation.posy = (long)komaInfo["posy"];
		komaInfomation.owner = (long)komaInfo["owner"];
		komaInfomation.promote = (bool)komaInfo["promote"];
	}
}