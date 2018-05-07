using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UIControllers
{
	public class ClickManager : MonoBehaviour  , IPointerClickHandler
	{
		public bool ToChange = false;
		public static GameObject ChosenCard;
		public static GameObject ChosenHex;
	
		// Update is called once per frame
		void Update()
		{

		
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
			if (eventData.pointerCurrentRaycast.gameObject.CompareTag("Card"))
			{
				eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().color=Color.cyan;
				eventData.pointerCurrentRaycast.gameObject.GetComponent<ClickManager>().ToChange = true;
				ChosenCard = eventData.pointerCurrentRaycast.gameObject;
				Debug.Log("Imie: " + ChosenCard.name);
			}
			else
			{
				Material m = AssetDatabase.LoadAssetAtPath("Assets/Assets-Materials/Materials/Units/MotherShip/steampunk robot_SteampunkRobot_AO 4.png", typeof(Material)) as Material;
				eventData.pointerCurrentRaycast.gameObject.GetComponentInChildren<Renderer>().material = m;
				ChosenHex = eventData.pointerCurrentRaycast.gameObject;
			}
		}

		public void Play()
		{
			if (ChosenCard != null) Debug.Log(ChosenCard.name + " " + ChosenHex.name);
			else Debug.Log(ChosenHex.name);
		}
	}
}
