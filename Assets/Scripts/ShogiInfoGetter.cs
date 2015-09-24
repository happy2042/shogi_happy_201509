using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class ShogiInfoGetter : MonoBehaviour {
	
	Wrapper wrapper;
	UserManager userManager;
	LoginManager loginManager;

	PlayerInformation playerInfo;
	PlayingInformation playInfo;

	/*
	string UsersURL = "http://192.168.3.83:3000/player.json";
	string PlayURL = "http://192.168.3.83:3000/play.json";
	string KomaURL = "http://192.168.3.83:3000/get_pieces.json";
	*/

	string UsersURL;
	string PlayURL;
	
	// Use this for initialization
	void Start () {
		wrapper = GameObject.Find ("Wrapper").GetComponent<Wrapper> ();
		userManager = GameObject.Find("UserManager").GetComponent<UserManager>();
		loginManager = GameObject.Find("LoginManager").GetComponent<LoginManager>();

		playerInfo = this.GetComponent<PlayerInformation>();
		playInfo = this.GetComponent<PlayingInformation>();

		UsersURL = "http://" + loginManager.GetURL() 
			+ "/plays/" + userManager.play_id.ToString() + "/users";
		PlayURL = "http://" + loginManager.GetURL() 
			+ "/plays/" + userManager.play_id.ToString();
		Debug.Log (UsersURL);
		Debug.Log (PlayURL);

		UsersInfoGet ();
		PlayInfoGet ();

	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public void UsersInfoGet(){
		WWW www = wrapper.GET (UsersURL, SetUsersInfo);
	}
	
	public void SetUsersInfo(Dictionary<string,object> json){
		/*
		if(json.ContainsKey("first_player")){
			Debug.Log ("setting player info: first");
			playerInfo.SetFirstInfo ((Dictionary<string, object>)json ["first_player"]);
		}
		else if(json.ContainsKey("last_player")){
			Debug.Log ("setting player info: last");
			playerInfo.SetLastInfo ((Dictionary<string, object>)json ["last_player"]);

		}
		*/
		playerInfo.SetFirstInfo ((Dictionary<string, object>)json ["first_player"]);
		playerInfo.SetLastInfo ((Dictionary<string, object>)json ["last_player"]);
	}
	
	public void PlayInfoGet(){
		WWW www = wrapper.GET (PlayURL, SetPlayInfo);
	}
	
	public void SetPlayInfo(Dictionary<string,object> json){
		playInfo.SetPlayingInfo (json);
	}
}