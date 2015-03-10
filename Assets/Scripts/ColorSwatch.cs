using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ColorSwatch : MonoBehaviour {

	public Swatch[] swatches;
	private int swatchIndex = 0;
	public GUIBs gUIBs;
	public Material[] materials;
	private int matIndex = 0;

	void Start(){
		DealSwatches();
		NameMaterial();
		SetSwatch();
	}

	void Update(){
		if(Input.GetButtonDown("SwatchUp")){
			Paint();
		}
		if(Input.GetButtonDown("MatUp")){
			SwitchMat();
		}
	}




	void DealSwatches(){
		foreach (Swatch s in swatches){
			var swGo = GameObject.Instantiate(gUIBs.swatchPrefab,new Vector3(0f,0f,0f),Quaternion.identity) as GameObject;
			swGo.transform.SetParent(gUIBs.swatchPannel,false);
			swGo.GetComponent<Image>().color = s.color;
		}
		foreach (Swatch s in swatches){
			var swGo = GameObject.Instantiate(gUIBs.swatchPrefab,new Vector3(0f,0f,0f),Quaternion.identity) as GameObject;
			swGo.transform.SetParent(gUIBs.swatchTopPannel,false);
			swGo.GetComponent<Image>().color = new Color(0f,0f,0f,0f);
			gUIBs.topSwatches.Add(swGo);
		}
	}

	void NameMaterial(){
		gUIBs.matName.text = materials[matIndex].name;
	}


	void SetSwatch(){
		for(int i = 0; i < swatches.Length; i++){
			if(swatches[i].color == materials[matIndex].color){
				gUIBs.swatchName.text = swatches[i].name;
				swatchIndex = i;
				gUIBs.topSwatches[i].GetComponent<Image>().color = swatches[i].color;
			}
			else{
				gUIBs.topSwatches[i].GetComponent<Image>().color = new Color(0f,0f,0f,0f);
			}
		}
	}

	void Paint(){
		swatchIndex ++;
		if(swatchIndex == swatches.Length){
			swatchIndex = 0;
		}
		materials[matIndex].color = swatches[swatchIndex].color;
		SetSwatch();
	}


	void SwitchMat(){
		matIndex ++;
		if(matIndex == materials.Length){
			matIndex = 0;
		}
		NameMaterial ();
		SetSwatch();
	}
}


[System.Serializable]
public class Swatch{
	public string name;
	public Color color;
}

[System.Serializable]
public class GUIBs{
	public Text matName;
	public Text swatchName;
	public RectTransform swatchPannel;
	public RectTransform swatchTopPannel;
	public List <GameObject> topSwatches;
	public GameObject swatchPrefab;

}