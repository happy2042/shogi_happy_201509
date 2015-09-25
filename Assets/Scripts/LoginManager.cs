using UnityEngine;
using System.Collections;

public class LoginManager : MonoBehaviour {

	public string playerName;
	public string url;
	public string playRoomNo;

	public GameObject successImage;
	public GameObject errorImage;
	public GameObject waitingImage;

	private GameObject parentObject;
	private GameObject cover;

	void Awake(){
		DontDestroyOnLoad(this.gameObject);
	}

	void Start(){
		parentObject = GameObject.Find("Canvas");
		cover = GameObject.Find ("Cover");
		cover.SetActive (false);
	}
	
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
		GameObject successPrefab = (GameObject)Instantiate(successImage);
		successPrefab.transform.SetParent (parentObject.transform, false);
	}

	public void ShowError(){
		GameObject errorPrefab = (GameObject)Instantiate(errorImage);
		errorPrefab.transform.SetParent (parentObject.transform, false);
	}

	public void ShowWaiting(){
		GameObject waitingPrefab = (GameObject)Instantiate(waitingImage);
		waitingPrefab.transform.SetParent (parentObject.transform, false);
		cover.SetActive (true);
	}
}
