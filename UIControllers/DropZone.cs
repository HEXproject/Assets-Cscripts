using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.UIControllers
{
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
                }if (this.transform.name == "Map")
                {
                    Debug.Log("HEX!!!");
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
}
