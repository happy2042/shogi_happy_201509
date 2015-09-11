using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class JsonConverter : MonoBehaviour {

	public Dictionary<string, object> JsonConv(WWW www){
		var json 
			= Json.Deserialize(www.text) as Dictionary<string, object>;

		return json;
	}
}
