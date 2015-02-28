using UnityEngine;
using System.Collections;

public class returnToMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void Update () {
		if(Input.GetKeyDown("escape")){
			Application.LoadLevel(0);
		}
	}
}
