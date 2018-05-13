using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
using UIControllers;
using UnityEditor;
using UnityEngine;


public class MovingCards : MonoBehaviour
{
	public List<GameObject> DeckOfCards = new List<GameObject>();
=======
using UnityEngine;

public class MovingCards : MonoBehaviour
{

	public Queue<GameObject> DeckOfCards = new Queue<GameObject>();
>>>>>>> master
	private int HandSize = 5;
	public GameObject Card;
	public GameObject Hand;
	private Vector3 velocity = Vector3.zero;
	public float smoothTime = 0.01f;
<<<<<<< HEAD
	public int number_of_mull = 0;

=======
	public bool toChange = false;
	Ray ray;
	RaycastHit hit;
>>>>>>> master



	GameObject createGameObjectFromSprite(Sprite s)
	{
		GameObject newHex = new GameObject();

		newHex.AddComponent<SpriteRenderer>();
		newHex.GetComponent<SpriteRenderer>().sprite = s;
<<<<<<< HEAD
=======

>>>>>>> master
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
<<<<<<< HEAD
			newHex.GetComponent<Transform>().name = "Card"+i.ToString();
			DeckOfCards.Add(newHex);
=======
			newHex.GetComponent<Transform>().name = "Card";
			DeckOfCards.Enqueue(newHex);
>>>>>>> master
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
<<<<<<< HEAD
			GameObject n = DeckOfCards[0];
			DeckOfCards.RemoveAt(0);
			moveHex(n, Hand);
			n.transform.SetParent(Hand.transform);
		    n.gameObject.SetActive(true);
=======
		GameObject n = DeckOfCards.Dequeue();
		n.SetActive(true);
		moveHex(n, Hand);
		n.transform.SetParent(Hand.transform);
>>>>>>> master
	}

	public void DoMulligan()
	{
<<<<<<< HEAD
		number_of_mull = 0;
		Debug.Log("dzieci" + Hand.transform.childCount);
		for (int i = 0; i < Hand.transform.childCount; i++)
		{ Debug.Log(Hand.transform.GetChild(i).transform.GetComponent<ClickManager>().ToChange);
			if (Hand.transform.GetChild(i).transform.GetComponent<ClickManager>().ToChange)
			{
				number_of_mull++;
				Debug.Log(number_of_mull);
				DeckOfCards.Add(Hand.transform.GetChild(i).gameObject);
				Hand.transform.GetChild(i).GetComponent<ClickManager>().ToChange = false;
				moveHex(Hand.transform.GetChild(i).gameObject, this.transform.gameObject);
				Hand.transform.GetChild(i).gameObject.SetActive(false);
				Hand.transform.GetChild(i).transform.SetParent(this.transform);
				i -= 1;
			}
		}
		for (int j = 0; j < number_of_mull; j++)
		{
			OnClick();
		}
=======
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
>>>>>>> master
	}

	// Use this for initialization
	void Start()
	{
<<<<<<< HEAD
=======
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
>>>>>>> master
		CreateCards();

	}

	// Update is called once per frame
	void Update()
	{
<<<<<<< HEAD

=======
		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("MouseDown");
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.transform.gameObject.CompareTag("Card"))
				{
					Debug.Log("Hit");
				}
			}
		}
>>>>>>> master
	}
}
