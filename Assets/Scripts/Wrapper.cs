using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wrapper : MonoBehaviour {
	JsonConverter jsonconverter;

	public delegate void Callback(Dictionary<string,object> json);

	public WWW GET(string url, Callback callback) {
		jsonconverter 
			= GameObject.Find("JsonConverter").GetComponent<JsonConverter>();		WWW www = new WWW (url);
		StartCoroutine (WaitForRequest (www, callback));
		return www;
	}

	public WWW POST(string url, Dictionary<string, string> post, Callback callback) {
		WWWForm form = new WWWForm();
		foreach(KeyValuePair<string,string> post_arg in post) {
			form.AddField(post_arg.Key, post_arg.Value);
		}
		WWW www = new WWW(url, form);
		StartCoroutine(WaitForRequest(www, callback));
		return www;
	}

	private IEnumerator WaitForRequest(WWW www, Callback callback) {
		yield return www;
		// check for errors
		if (www.error == null) {
			Debug.Log("WWW Ok!: " + www.text);
			Dictionary<string, object> json = jsonconverter.JsonConv (www);
			callback(json);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}
	}
}
