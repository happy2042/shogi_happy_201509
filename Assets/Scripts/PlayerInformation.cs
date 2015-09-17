using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class PlayerInformation : Object {

	Dictionary<string, object> first_player;
	Dictionary<string, object> last_player;

	public void SetFirstInfo(Dictionary<string, object> first){
		first_player.Add("user_id", (long)first["user_id"]);
		first_player.Add ("name", (string)first ["name"]);
	}

	public void SetLastInfo(Dictionary<string, object> last){
		last_player.Add("user_id", (long)last["user_id"]);
		last_player.Add ("name", (string)last ["name"]);
	}

	public Dictionary<string, object> GetFirstInfo(){
		return first_player;
	}

	public Dictionary<string, object> GetLastInfo(){
		return last_player;
	}
}
