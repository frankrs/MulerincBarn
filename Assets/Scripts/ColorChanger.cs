﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ColorChanger : MonoBehaviour {

	public float sightDist = 7.5f;
	public Color colorSampled;
	public Color[] availableColors;
	public LayerMask switchable;
	public Text matName;
	public GameObject colorPannel;
	public GameObject swatchPrefab;
	public int swatchIndex = 0;
	public List<GameObject> swatchObjects;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if(Physics.Raycast(transform.position,transform.forward, out hit ,sightDist, switchable)){
			colorSampled  = hit.collider.renderer.sharedMaterial.GetColor("_Color");

			if(matName.text != hit.collider.renderer.sharedMaterial.name){
				matName.text = hit.collider.renderer.sharedMaterial.name;
				DestroySwatches();
				swatchIndex = 0;
				}

			if(Input.GetKeyDown("3") && colorPannel.transform.childCount > 0){
				hit.collider.gameObject.SendMessage("ChangeColor",availableColors[swatchIndex],SendMessageOptions.DontRequireReceiver);
			}

			if(Input.GetKeyDown("2") && colorPannel.transform.childCount > 0){
				swatchIndex ++;
				if(swatchIndex == colorPannel.transform.childCount){
					swatchIndex = 0;
				}
				DestroySwatches();
				DrawSwatches(hit);
			}

			if(Input.GetKeyDown("1") && colorPannel.transform.childCount == 0){
				DrawSwatches(hit);
			}
		}
		else{
			colorSampled = Color.white;
			matName.text = "Empty";
			if(colorPannel.transform.childCount == 0){
				return;
			}
			swatchIndex = 0;
			DestroySwatches();
		}
	}

	void OnDrawGizmos(){
		Debug.DrawRay(transform.position,transform.forward * sightDist,Color.red);
	}



	public void DestroySwatches() {
		foreach(GameObject s in swatchObjects){
			Destroy(s);
		}
		swatchObjects.Clear();
	}


	public void DrawSwatches(RaycastHit hit){
		ColorSwatch cS = hit.collider.GetComponent<ColorSwatch>();
		if (cS == null){
			return;
		}
		availableColors = cS.swatches;
		foreach(Color c in availableColors){
			var swatch = GameObject.Instantiate(swatchPrefab,new Vector3(0f,0f,0f),Quaternion.identity) as GameObject;
			var nC = new Color();
			nC = c;
			if(c == availableColors[swatchIndex]){
				nC.a = 1f;
			}
			else{
				nC.a = .5f;
			}
			swatch.GetComponent<Image>().color = nC;
			swatch.transform.parent = colorPannel.transform;
			swatchObjects.Add(swatch);
		}
	}


}
