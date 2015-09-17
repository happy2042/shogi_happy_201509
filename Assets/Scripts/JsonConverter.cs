using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class JsonConverter : Object {

	// Json形式にパースする
	public static Dictionary<string, object> JsonConv(string fetchString){
		return Json.Deserialize(fetchString) as Dictionary<string, object>;
	}
}