using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class PlayingInformation : MonoBehaviour {

	public long turn_count;
	public long watcher_count;
	public long turn_player;
	public string state;

	public void SetPlayingInfo(Dictionary<string, object> playInfo){
		turn_count = (long)playInfo["turn_count"];
		watcher_count = (long)playInfo["watcher_count"];
		turn_player = (long)playInfo["turn_player"];
		state = (string)playInfo["state"];
	}

}
