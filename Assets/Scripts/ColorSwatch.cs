using UnityEngine;
using System.Collections;

public class ColorSwatch : MonoBehaviour {

	public Color[] swatches;


	public void ChangeColor(Color c){
		//Debug.Log(c);
		//renderer.material.color = c;
		renderer.sharedMaterial.SetColor("_Color",c);
	}
}
