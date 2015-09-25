using UnityEngine;
using System.Collections;

public class KomaMove : MonoBehaviour {

	public GameObject activeMove;
	private UserManager userManager;

	// Use this for initialization
	void Start () {
		activeMove = (GameObject)Resources.Load ("Prefabs/ActiveMove");
		userManager = GameObject.Find("UserManager").GetComponent<UserManager>();
	}

	public void OnClick(){
		if(userManager.user_id.Equals(this.GetComponent<KomaInformation>().owner))
			MoveSet ();
	}

	void MoveSet(){
		GameObject movePrefab = (GameObject)Instantiate(activeMove);
		movePrefab.transform.SetParent (this.transform, false);
	}
}
