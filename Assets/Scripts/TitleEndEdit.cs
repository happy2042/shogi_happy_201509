using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleEndEdit : MonoBehaviour {

	InputField playerName;
	InputField Address;
	InputField RoomNo;

	LoginManager loginManager;

	void Start(){
		playerName = GameObject.Find ("InputName").GetComponent<InputField> ();
		Address = GameObject.Find ("InputAddress").GetComponent<InputField> ();
		RoomNo = GameObject.Find ("InputRoomNo").GetComponent<InputField> ();

		loginManager = GameObject.Find ("LoginManager").GetComponent<LoginManager> ();
	}


	public void NameEndEdit(){
		loginManager.SetPlayerName (playerName.text);
	}

	public void AddressEndEdit(){
		loginManager.SetURL (Address.text);
	}

	public void RoomEndEdit(){
		loginManager.SetRoomNo (RoomNo.text);
	}
}
