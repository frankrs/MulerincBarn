using UnityEngine;
using System.Collections;

public class ColorSwatch : MonoBehaviour {

	public Swatch[] swatches;


	public void ChangeColor(Color c){
		//Debug.Log(c);
		//renderer.material.color = c;
		renderer.sharedMaterial.SetColor("_Color",c);
	}
}


[System.Serializable]
public class Swatch{
	public string name;
	public Color color;
}