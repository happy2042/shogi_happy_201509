using UnityEngine;
using System.Collections;

public class KomaMove : MonoBehaviour {

	public GameObject activeMove;

	// Use this for initialization
	void Start () {
		activeMove = (GameObject)Resources.Load ("Prefabs/ActiveMove");
	}

	public void OnClick(){
		MoveSet ();
	}

	void MoveSet(){
		GameObject movePrefab = (GameObject)Instantiate(activeMove);
		movePrefab.transform.SetParent (this.transform, false);
	}
}
