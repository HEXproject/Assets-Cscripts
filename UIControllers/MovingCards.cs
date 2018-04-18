using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCards : MonoBehaviour
{

	public Queue<GameObject> DeckOfCards = new Queue<GameObject>();
	private int HandSize = 5;
	public GameObject Card;
	public GameObject Hand;
	private Vector3 velocity = Vector3.zero;
	public float smoothTime = 0.01f;
	public bool toChange = false;
	Ray ray;
	RaycastHit hit;



	GameObject createGameObjectFromSprite(Sprite s)
	{
		GameObject newHex = new GameObject();

		newHex.AddComponent<SpriteRenderer>();
		newHex.GetComponent<SpriteRenderer>().sprite = s;

		newHex.AddComponent<PolygonCollider2D>();

		return newHex;
	}

	void CreateCards()
	{
		for (int i = 0; i < HandSize; ++i)
		{
			GameObject newHex = Instantiate(Card);
			newHex.transform.SetParent(transform);
			newHex.GetComponent<Transform>().position =
				new Vector3(transform.position.x, transform.position.y, transform.position.z);
			newHex.GetComponent<Transform>().name = "Card";
			DeckOfCards.Enqueue(newHex);
			newHex.SetActive(false);
		}
	}

	void moveHex(GameObject movingObject, GameObject destination)
	{
		Vector3 targetPosition = destination.GetComponent<Transform>().position;
		movingObject.GetComponent<Transform>().position = Vector3.SmoothDamp(movingObject.GetComponent<Transform>().position,
			targetPosition, ref velocity, smoothTime);
		if (Vector3.Distance(movingObject.GetComponent<Transform>().position, targetPosition) < 1f)
		{
			movingObject.GetComponent<Transform>().position = targetPosition;
			velocity = Vector3.zero;
		}
	}

	public void OnClick()
	{
		GameObject n = DeckOfCards.Dequeue();
		n.SetActive(true);
		moveHex(n, Hand);
		n.transform.SetParent(Hand.transform);
	}

	public void DoMulligan()
	{
		for (int i = 0; i < Hand.transform.childCount; i++)
		{
			if (Hand.transform.GetChild(i).transform.hasChanged == true)
			{
				DeckOfCards.Enqueue(Hand.transform.GetChild(i).gameObject);
				Hand.transform.GetChild(i).gameObject.active = false;
				Hand.transform.GetChild(i).hasChanged = false;
				Hand.transform.GetChild(i).transform.SetParent(this.transform);
				OnClick();
			}
		}
	}

	// Use this for initialization
	void Start()
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		CreateCards();

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0)) {
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            
			RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
			if (hit.collider != null) {
				Debug.Log(hit.collider.gameObject.name);
				hit.collider.attachedRigidbody.AddForce(Vector2.up);
			}
		}
	}
}
