using UnityEngine;
using System.Collections;

public class LoginManager : MonoBehaviour {

	private string playerName;
	private string url;
	private string playRoomNo;
	
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
}
