﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using MiniJSON;

public class TitleLogin : MonoBehaviour {

	LoginManager loginManager;
	UserManager userManager;

	private bool loginSuccess = false;
	private float getCounter = 0f;

	// Use this for initialization
	void Start () {
		loginManager = GameObject.Find ("LoginManager").GetComponent<LoginManager> ();
		userManager = GameObject.Find ("UserManager").GetComponent<UserManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (loginSuccess) {
			getCounter += Time.deltaTime;
			if(getCounter > 1.0f){
				StartCoroutine (StateAccess());
				getCounter = 0;
			}
		}
	}

	public void OnClick(){
		StartCoroutine (LoginAccess());
	}
	
	
	private IEnumerator LoginAccess(){
		WWWForm form = new WWWForm ();

		form.AddField ("name", loginManager.GetPlayerName());
		form.AddField ("room_no", loginManager.GetRoomNo());

		WWW download = new WWW ("http://" + loginManager.GetURL() + "/users/login", form);

		yield return download;
		if (download.error == null) {
			Debug.Log (download.text);
			loginManager.ShowSuccess();
			loginSuccess = true;
			loginManager.ShowWaiting();
			// cast
			var json = Json.Deserialize(download.text) as Dictionary<string, object>;

			// keep status
			userManager.user_id = (long)json["user_id"];
			userManager.play_id = (long)json["play_id"];
			userManager.state = (string)json["state"];
			userManager.role = (string)json["role"];

		
		} else {
			Debug.Log ("Error");
			loginManager.ShowError();
		}
	}

	private IEnumerator StateAccess(){
		Debug.Log ("state_access");
		WWW www = new WWW("http://" + loginManager.GetURL() + "/plays/" + userManager.play_id + "/state");
		yield return www;
		if (www.error == null) {
			Debug.Log (www.text);
			var json = Json.Deserialize (www.text) as Dictionary<string, object>;
			if ((string)json ["state"] == "playing") 
				Application.LoadLevel ("main");
		} else {
			Debug.Log("state_access_error");
			yield break;
		}
	}
}
