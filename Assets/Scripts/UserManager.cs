using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserManager : MonoBehaviour {

	public Dictionary<string, object> userInfo;

	void Awake(){
		DontDestroyOnLoad(this.gameObject);
	}

	// Use this for initialization
	void Start () {
		userInfo = new Dictionary<string, object> ();
	}
}