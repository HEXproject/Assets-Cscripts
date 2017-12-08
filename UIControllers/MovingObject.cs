using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {

    public Sprite hexSprite;
    public Sprite hexBGSprite;

    public List<GameObject> handBG = new List<GameObject>();
    public List<GameObject> deckList = new List<GameObject>();
    private GameObject EndOfTurnButton;
    private GameObject HexPortraitHex;
    private GameObject GravyardButton;
    public GameObject mulliganHex;

    public float smoothTime = 0.01f;
    private Vector3 velocity = Vector3.zero;

    public int HandSize = 4;
    public int DeckSize = 10;
    public int numberOfDrawnHex = 0;
    public int ActualNumberToDraw = 2;
    public bool domulligan = false;

    void Start () {
        GameObject Hand = new GameObject();
        GameObject Deck = new GameObject();
        
        Hand.GetComponent<Transform>().parent = gameObject.GetComponent<Transform>();
        Deck.GetComponent<Transform>().parent = gameObject.GetComponent<Transform>();        

        Hand.GetComponent<Transform>().name = "HandBG";
        Deck.GetComponent<Transform>().name = "Deck";

        //HexPortraitHex
        HexPortraitHex = createGameObjectFromSprite(hexSprite);
        HexPortraitHex.GetComponent<Transform>().position = new Vector3(8, 6, -8);
        HexPortraitHex.GetComponent<Transform>().name = "HexPortraitHex";
        HexPortraitHex.GetComponent<SpriteRenderer>().color = Color.grey;
        HexPortraitHex.GetComponent<Transform>().localScale = new Vector3(5, 5, 5);
        HexPortraitHex.GetComponent<Transform>().Rotate(new Vector3(0, 0, 30));
        HexPortraitHex.GetComponent<Transform>().parent = gameObject.GetComponent<Transform>();

        //hexTraits
        for (int i = 0; i < 3; ++i)
        {
            GameObject newHex = createGameObjectFromSprite(hexSprite);
            newHex.GetComponent<Transform>().parent = HexPortraitHex.GetComponent<Transform>();
            if(i==1) newHex.GetComponent<Transform>().position = new Vector3(8, 9, -8);
            else newHex.GetComponent<Transform>().position = new Vector3(5.5f+2.5f*i, 7.5f, -8);
            newHex.GetComponent<Transform>().Rotate(new Vector3(0, 0, 30));
            newHex.GetComponent<Transform>().name = "HexTrait" + i.ToString();
            newHex.GetComponent<SpriteRenderer>().color = Color.cyan;
        }

        //endOfTurnButton
        EndOfTurnButton = createGameObjectFromSprite(hexSprite);
        EndOfTurnButton.GetComponent<Transform>().position = new Vector3(0, 17, -8);
        EndOfTurnButton.GetComponent<Transform>().name = "EndOfTurnButton";
        EndOfTurnButton.GetComponent<SpriteRenderer>().color = Color.black;
        EndOfTurnButton.GetComponent<Transform>().localScale = new Vector3(5, 5, 5);
        EndOfTurnButton.GetComponent<Transform>().parent = gameObject.GetComponent<Transform>();

        //removeButton
        GravyardButton = createGameObjectFromSprite(hexSprite);
        GravyardButton.GetComponent<Transform>().position = new Vector3(-11.5f, 4, -8);
        GravyardButton.GetComponent<Transform>().name = "RemoveButton";
        GravyardButton.GetComponent<SpriteRenderer>().color = Color.white;
        GravyardButton.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        GravyardButton.AddComponent<DeleteButton>();
        GravyardButton.GetComponent<Transform>().parent = gameObject.GetComponent<Transform>();

        ////handBG
        //GameObject HexHandBG = createGameObjectFromSprite(hexBGSprite);
        ////HexHandBG.GetComponent<Transform>().parent = gameObject.GetComponent<Transform>();
        //HexHandBG.GetComponent<Transform>().position = new Vector3(-6.5f, 6, -5);
        //HexHandBG.GetComponent<Transform>().localScale = new Vector3(12, 20, 0);
        //HexHandBG.GetComponent<Transform>().name = "HandBackground";
        //HexHandBG.GetComponent<SpriteRenderer>().color = Color.yellow;

        //hand
        for ( int i = 0; i < HandSize; ++i)
        {
            GameObject newHex = createGameObjectFromSprite(hexSprite);
            newHex.GetComponent<Transform>().position = new Vector3(i*2 - 10, 6, -8);
            newHex.GetComponent<Transform>().name = "HexHandBG";
            newHex.GetComponent<SpriteRenderer>().color = Color.red;
            newHex.GetComponent<Transform>().localScale = new Vector3(2, 2, 2);
            newHex.GetComponent<Transform>().parent = Hand.GetComponent<Transform>();
            handBG.Add(newHex);
        }

        //deck
        for (int i = 0; i < DeckSize; ++i)
        {
            GameObject newHex = createGameObjectFromSprite(hexSprite);
            newHex.GetComponent<Transform>().position = new Vector3(-11.5f, 8, -8);
            newHex.GetComponent<Transform>().name = "HexDeckElement";
            newHex.GetComponent<SpriteRenderer>().color = Color.green;
            newHex.GetComponent<Transform>().parent = Deck.GetComponent<Transform>();
            newHex.AddComponent<DrawOnClick>();
            deckList.Add(newHex);
        }

    }

    GameObject createGameObjectFromSprite(Sprite s)
    {
        GameObject newHex = new GameObject();

        newHex.AddComponent<SpriteRenderer>();
        newHex.GetComponent<SpriteRenderer>().sprite = s;

        newHex.AddComponent<PolygonCollider2D>();

        return newHex;
    }
	
    
    void moveHex(GameObject movingObject, GameObject destination)
    {
        Vector3 targetPosition = destination.GetComponent<Transform>().position;
        movingObject.GetComponent<Transform>().position = Vector3.SmoothDamp(movingObject.GetComponent<Transform>().position, targetPosition, ref velocity, smoothTime);
        if (Vector3.Distance(movingObject.GetComponent<Transform>().position, targetPosition) < 1f)
        {
            movingObject.GetComponent<Transform>().position = targetPosition;
            velocity = Vector3.zero;
        }
    }
    
    void drawHex(int numberToDraw)
    {
        if(handEmptiness() > 0)
        {
            if (numberOfDrawnHex < numberToDraw)
            {
                moveHex(deckList[0], handBG[HandSize - handEmptiness()]);
                if (Vector3.Distance( deckList[0].GetComponent<Transform>().position, handBG[HandSize - handEmptiness()].GetComponent<Transform>().position) < 0.1f)
                {
                    handBG[HandSize - handEmptiness()].GetComponent<Transform>().position = new Vector3(handBG[HandSize - handEmptiness()].GetComponent<Transform>().position.x,
                        handBG[HandSize - handEmptiness()].GetComponent<Transform>().position.y, handBG[HandSize - handEmptiness()].GetComponent<Transform>().position.z + 0.01f);
                    deckList[0].GetComponent<Transform>().parent = handBG[HandSize - handEmptiness()].GetComponent<Transform>();
                    Destroy(deckList[0].GetComponent<DrawOnClick>());
                    deckList[0].AddComponent<ToRemove>();
                    deckList[0].AddComponent<mouseOverHex>();
                    deckList.Remove(deckList[0]);
                    numberOfDrawnHex++;
                }
            }
        }    
    }

    void mulligan(GameObject HexToMulligan)
    {
        if (deckList.Count > 1)
        {
            //znacznie zwalnia prędkość powracającego hexa
            
            if (Vector3.Distance(deckList[1].GetComponent<Transform>().position, 
                HexToMulligan.GetComponent<Transform>().position) < 0.1f)
            {
                moveHex(deckList[0], HexToMulligan.GetComponent<Transform>().parent.gameObject);
                if (Vector3.Distance(deckList[0].GetComponent<Transform>().position, 
                    HexToMulligan.GetComponent<Transform>().parent.GetComponent<Transform>().position) < 0.1f)
                {
                    HexToMulligan.GetComponent<Transform>().parent.GetComponent<Transform>().position = new Vector3
                        (deckList[0].GetComponent<Transform>().position.x,
                        deckList[0].GetComponent<Transform>().position.y, 
                        deckList[0].GetComponent<Transform>().position.z + 0.01f);
                    
                    Destroy(HexToMulligan.GetComponent<ToRemove>());
                    Destroy(HexToMulligan.GetComponent<mouseOverHex>());
                    HexToMulligan.AddComponent<DrawOnClick>();

                    Debug.Log(deckList.Count);

                    GameObject a = HexToMulligan.GetComponent<Transform>().parent.gameObject;
                    HexToMulligan.GetComponent<Transform>().parent = deckList[0].GetComponent<Transform>().parent;
                    deckList[0].GetComponent<Transform>().parent = a.GetComponent<Transform>();

                    Debug.Log(deckList.Count);

                    Destroy(deckList[0].GetComponent<DrawOnClick>());
                    deckList[0].AddComponent<ToRemove>();
                    deckList[0].AddComponent<mouseOverHex>();
                    deckList.Remove(deckList[0]);
                    HexToMulligan.GetComponent<Transform>().position = deckList[0].GetComponent<Transform>().position;

                    domulligan = false;
                    mulliganHex = null;
                }
            }
            else moveHex(HexToMulligan, deckList[1]);

        }        
    }



    int handEmptiness()
    {
        int emptyHex = 0;
        for( int i = 0; i < HandSize; ++i)
        {
            if (handBG[i].GetComponent<Transform>().childCount == 0) emptyHex++; 
        }
        if (emptyHex == 0) ActualNumberToDraw = HandSize;
        return emptyHex;
    }
    void Update ()
    {
        drawHex(ActualNumberToDraw);
        if (domulligan)
        {
            Debug.Log(mulliganHex);
            mulligan(mulliganHex);
        }
    }
}
