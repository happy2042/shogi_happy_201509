using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class PlayerInformation : MonoBehaviour {

	public Dictionary<string, object> first_player;
	public Dictionary<string, object> last_player;

	public delegate void Callback();

	void Start(){
		first_player = new Dictionary<string, object>();
		last_player = new Dictionary<string, object>();
	}

	public void SetFirstInfo(Dictionary<string, object> first){
		first_player.Add("user_id", (long)first["user_id"]);
		first_player.Add ("name", (string)first ["name"]);
	}

	public void SetLastInfo(Dictionary<string, object> last, Callback callback){
		last_player.Add("user_id", (long)last["user_id"]);
		last_player.Add ("name", (string)last ["name"]);
		callback();
	}

	public Dictionary<string, object> GetFirstInfo(){
		return first_player;
	}

	public Dictionary<string, object> GetLastInfo(){
		return last_player;
	}
}
