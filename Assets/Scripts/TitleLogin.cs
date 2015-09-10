using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleLogin : MonoBehaviour {

	private LoginManager loginManager;

	// Use this for initialization
	void Start () {
		loginManager = GameObject.Find ("LoginManager").GetComponent<LoginManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void OnClick(){
		StartCoroutine (LoginAccess());
	}
	
	
	private IEnumerator LoginAccess(){
		string playerName = "happy";
		string url = "http://192.168.33.11:3000/users/login";
		string playRoomNo = "1";

		WWWForm form = new WWWForm ();
		
		form.AddField ("name", playerName);
		form.AddField ("room_no", playRoomNo);
		//form.AddField ("name", loginManager.GetPlayerName());
		//form.AddField ("room_no", loginManager.GetRoomNo());


		WWW download = new WWW (url, form);
		//WWW download = new WWW (loginManager.GetURL(), form);

		yield return download;
		if (download.error == null) {
			Debug.Log (download.text);
			//
			// scene load
			//
		} else {
			Debug.Log ("Error");
		}
	}
}
