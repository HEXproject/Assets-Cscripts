using System.Collections.Generic;
using UnityEngine;

namespace Assets.UIControllers
{
    public class MovingCards : MonoBehaviour
    {
        public List<GameObject> DeckOfCards = new List<GameObject>();

        private int HandSize = 5;
        public GameObject Card;
        public GameObject Hand;
        private Vector3 velocity = Vector3.zero;
        public float smoothTime = 0.01f;
        public int number_of_mull = 0;

        GameObject CreateGameObjectFromSprite(Sprite s)
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
                newHex.GetComponent<Transform>().name = "Card" + i.ToString();
                DeckOfCards.Add(newHex);
                newHex.SetActive(false);
            }
        }

        void MoveHex(GameObject movingObject, GameObject destination)
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
            var n = DeckOfCards[0];
            DeckOfCards.RemoveAt(0);
            MoveHex(n, Hand);
            n.transform.SetParent(Hand.transform);
            n.gameObject.SetActive(true);
        }

        public void DoMulligan()
        {
            number_of_mull = 0;
            Debug.Log("dzieci" + Hand.transform.childCount);
            for (var i = 0; i < Hand.transform.childCount; i++)
            {
                Debug.Log(Hand.transform.GetChild(i).transform.GetComponent<ClickManager>().ToChange);
                if (Hand.transform.GetChild(i).transform.GetComponent<ClickManager>().ToChange)
                {
                    number_of_mull++;
                    Debug.Log(number_of_mull);
                    DeckOfCards.Add(Hand.transform.GetChild(i).gameObject);
                    Hand.transform.GetChild(i).GetComponent<ClickManager>().ToChange = false;
                    MoveHex(Hand.transform.GetChild(i).gameObject, this.transform.gameObject);
                    Hand.transform.GetChild(i).gameObject.SetActive(false);
                    Hand.transform.GetChild(i).transform.SetParent(this.transform);
                    i -= 1;
                }
            }

            for (var j = 0; j < number_of_mull; j++)
            {
                OnClick();
            }
        }

        // Use this for initialization
        void Start()
        {
            CreateCards();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
