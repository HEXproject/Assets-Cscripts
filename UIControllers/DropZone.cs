using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	public void OnDrop(PointerEventData eventData)
	{
		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if (d != null)
		{
			d.parentToReturnTo = this.transform;
			if (this.transform.name == "DropArea")
			{
				eventData.pointerDrag.SetActive(false);
				Destroy(eventData.pointerDrag.GetComponent<Draggable>().placeholder);
<<<<<<< HEAD
			}if (this.transform.name == "Map")
			{
				Debug.Log("HEX!!!");
=======
>>>>>>> master
			}
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}
}
