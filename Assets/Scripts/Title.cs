using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {


	void Update () {
		if(Input.GetKeyDown("escape")){
			Application.Quit();
		}
	}


	public void LoadScene(int i){
		Application.LoadLevel(i);
	}
}
