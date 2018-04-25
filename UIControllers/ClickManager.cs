using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour {


	
	// Update is called once per frame
	void Update(){
		if (Input.GetMouseButtonDown(0)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)){
				Debug.Log("HIT!");
				Debug.Log(hit.transform.gameObject.name);
			}
		}
	}
	
}
