using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class KomaGenerator : MonoBehaviour {

	string url = "http://192.168.3.83:3000/pieces.json";

	public GameObject koma;

	Wrapper wrapper = GameObject.Find("Wrapper").GetComponent<Wrapper>();
	JsonConverter jsonconverter 
		= GameObject.Find("JsonConverter").GetComponent<JsonConverter>();

	// 駒の情報を元に
	// 駒の座標をスクリーン座標に変換
	// する予定
	public void KomaPosGet(){
		var json = jsonconverter.JsonConv (wrapper.GET(url));
	}

	// 駒をInstansiateする
	// 予定
	public void KomaArrange(){

	}
}