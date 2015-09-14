using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class KomaGenerator : MonoBehaviour {

	string url = "http://192.168.3.83:3000/pieces.json";

	public GameObject koma;
	public GameObject canvasObject;

	Wrapper wrapper;
	JsonConverter jsonconverter;

	void Start(){
		wrapper = GameObject.Find("Wrapper").GetComponent<Wrapper>();
		jsonconverter 
			= GameObject.Find("JsonConverter").GetComponent<JsonConverter>();
		canvasObject = GameObject.Find ("Canvas");

		KomaInfoGet ();
	}

	public void SetKomaArrange(Dictionary<string,object> json) {
		Dictionary<string, object> info;
		for(int i = 0; i < 40; i++){
			info = (Dictionary<string,object>)json[(i+1).ToString()];
			// 生成
			KomaArrange(info);
		}
	}
	
	// 駒の情報を取得
	public void KomaInfoGet(){


		WWW www = wrapper.GET (url, SetKomaArrange);
		//var json = jsonconverter.JsonConv (www);

		//for(int i = 0; i < 40; i++){
		//	info = (Dictionary<string, object>)json[(i+1).ToString()];
			// 生成
		//	KomaArrange(info);
		//}
	}
	
	// 駒を生成する
	public void KomaArrange(Dictionary<string, object> komaInfo){
		koma = (GameObject)Resources.Load ("Prefabs/koma");
		KomaInfoSet (komaInfo);

		GameObject komaPrefab = (GameObject)Instantiate (koma, 
		                                                 new Vector3(), 
		                                                 Quaternion.identity);
		komaPrefab.transform.SetParent (canvasObject.transform, false);

		komaPrefab.GetComponent<KomaInformation> ().MyPosition ();
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