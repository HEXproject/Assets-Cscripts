using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickManager : MonoBehaviour  , IPointerClickHandler
{
	public bool ToChange = false;

	
	// Update is called once per frame
	void Update()
	{

		
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
		eventData.pointerCurrentRaycast.gameObject.GetComponent<ClickManager>().ToChange = true;
		
	}
}
