using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using MiniJSON;

public class TitleLogin : MonoBehaviour {

	LoginManager loginManager;
	UserManager userManager;


	// Use this for initialization
	void Start () {
		loginManager = GameObject.Find ("LoginManager").GetComponent<LoginManager> ();
		userManager = GameObject.Find ("UserManager").GetComponent<UserManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void OnClick(){
		StartCoroutine (LoginAccess());
	}
	
	
	private IEnumerator LoginAccess(){
		/*
		string playerName = "happy";
		string url = "http://192.168.33.11:3000/users/login";
		string playRoomNo = "1";
		*/

		WWWForm form = new WWWForm ();

		/*
		form.AddField ("name", playerName);
		form.AddField ("room_no", playRoomNo);
		*/
		form.AddField ("name", loginManager.GetPlayerName());
		form.AddField ("room_no", loginManager.GetRoomNo());


		//WWW download = new WWW (url, form);
		WWW download = new WWW (loginManager.GetURL(), form);

		yield return download;
		if (download.error == null) {
			Debug.Log (download.text);
			// cast
			var json = Json.Deserialize(download.text) as Dictionary<string, object>;

			// keep status
			userManager.userInfo.Add("user_id", (long)json["user_id"]);
			userManager.userInfo.Add("play_id", (long)json["play_id"]);
			userManager.userInfo.Add("state", (string)json["state"]);
			userManager.userInfo.Add("role", (string)json["role"]);

			// scene load
			Application.LoadLevel("main");
		} else {
			Debug.Log ("Error");
		}
	}
}
