using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserManager : MonoBehaviour {

	public Dictionary<string, object> userInfo;

	public long user_id;
	public long play_id;
	public string state;
	public string role;

	void Awake(){
		DontDestroyOnLoad(this.gameObject);
	}

	// Use this for initialization
	void Start () {
		userInfo = new Dictionary<string, object> ();
	}
}