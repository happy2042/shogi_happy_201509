using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class ShogiInfoGetter : MonoBehaviour {
	
	Wrapper wrapper;
	PlayerInformation playerInfo;
	PlayingInformation playInfo;
	bool enemyTurn = false;
	
	
	string UsersURL = "http://192.168.3.83:3000/player.json";
	string PlayURL = "http://192.168.3.83:3000/play.json";
	string KomaURL = "http://192.168.3.83:3000/pieces.json";
	
	
	// Use this for initialization
	void Start () {
		wrapper = GameObject.Find("Wrapper").GetComponent<Wrapper>();
		playerInfo = new PlayerInformation ();
		playInfo = new PlayingInformation ();
		
		UsersInfoGet ();
		PlayInfoGet ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void UsersInfoGet(){
		WWW www = wrapper.GET (UsersURL, SetUsersInfo);
		if(www.error != null) 
			Debug.Log("Error_UsersInfoGet");
	}
	
	void SetUsersInfo(Dictionary<string,object> json){
		playerInfo.SetFirstInfo ((Dictionary<string, object>)json["first_player"]);
		playerInfo.SetLastInfo ((Dictionary<string, object>)json["last_player"]);
	}
	
	void PlayInfoGet(){
		WWW www = wrapper.GET (PlayURL, SetPlayInfo);
		if(www.error != null) 
			Debug.Log("Error_PlayInfoGet");
	}
	
	void SetPlayInfo(Dictionary<string,object> json){
		playInfo.SetPlayingInfo (json);
	}
}