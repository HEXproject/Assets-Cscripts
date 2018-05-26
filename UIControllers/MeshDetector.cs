using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.UIControllers
{
    public class MeshDetector : MonoBehaviour, IPointerDownHandler
    {
        void Start()
        {
            AddPhysicsRaycaster();
        }

        void AddPhysicsRaycaster()
        {
            var physicsRaycaster = GameObject.FindObjectOfType<PhysicsRaycaster>();
            if (physicsRaycaster == null)
            {
                Camera.main.gameObject.AddComponent<PhysicsRaycaster>();
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
        }

        //Implement Other Events from Method 1
    }
}
