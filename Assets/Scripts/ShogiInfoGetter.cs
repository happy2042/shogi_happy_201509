using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class ShogiInfoGetter : MonoBehaviour {
	
	Wrapper wrapper;

	PlayerInformation playerInfo;
	PlayingInformation playInfo;
	
	string UsersURL = "http://192.168.3.83:3000/player.json";
	string PlayURL = "http://192.168.3.83:3000/play.json";
	string KomaURL = "http://192.168.3.83:3000/get_pieces.json";
	
	
	// Use this for initialization
	void Start () {
		wrapper = GameObject.Find ("Wrapper").GetComponent<Wrapper> ();

		playerInfo = this.GetComponent<PlayerInformation>();
		playInfo = this.GetComponent<PlayingInformation>();
		
		UsersInfoGet ();
		PlayInfoGet ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public void UsersInfoGet(){
		WWW www = wrapper.GET (UsersURL, SetUsersInfo);
		if(www.error != null) 
			Debug.Log("Error_UsersInfoGet");
	}
	
	public void SetUsersInfo(Dictionary<string,object> json){
		if(json.ContainsKey("first_player")){
			Debug.Log ("setting player info: first");
			playerInfo.SetFirstInfo ((Dictionary<string, object>)json ["first_player"]);
		}
		else if(json.ContainsKey("last_player")){
			Debug.Log ("setting player info: last");
			playerInfo.SetLastInfo ((Dictionary<string, object>)json ["last_player"]);

		}
	}
	
	public void PlayInfoGet(){
		WWW www = wrapper.GET (PlayURL, SetPlayInfo);
		if(www.error != null) 
			Debug.Log("Error_PlayInfoGet");
	}
	
	public void SetPlayInfo(Dictionary<string,object> json){
		playInfo.SetPlayingInfo (json);
	}
}