﻿using UnityEngine;
using System.Collections;

public class LoginManager : MonoBehaviour {

	private string playerName;
	private string url;
	private string playRoomNo;

	public GameObject successImage;
	public GameObject errorImage;
	public GameObject waitingImage;
	
	public void SetPlayerName(string PlayerName){
		playerName = PlayerName;
	}

	public string GetPlayerName(){
		return playerName;
	}
	
	public void SetURL(string URL){
		url = URL;
	}

	public string GetURL(){
		return url;
	}

	public void SetRoomNo(string RoomNo){
		playRoomNo = RoomNo;
	}

	public string GetRoomNo(){
		return playRoomNo;
	}

	public void ShowSuccess(){
		GameObject parentObject = GameObject.Find("Canvas");
		GameObject successPrefab = (GameObject)Instantiate(successImage);
		successPrefab.transform.SetParent (parentObject.transform, false);
	}

	public void ShowError(){
		GameObject parentObject = GameObject.Find("Canvas");
		GameObject errorPrefab = (GameObject)Instantiate(errorImage);
		errorPrefab.transform.SetParent (parentObject.transform, false);
	}

	public void ShowWaiting(){
		GameObject parentObject = GameObject.Find("Canvas");
		GameObject waitingPrefab = (GameObject)Instantiate(waitingImage);
		waitingPrefab.transform.SetParent (parentObject.transform, false);
	}
}
