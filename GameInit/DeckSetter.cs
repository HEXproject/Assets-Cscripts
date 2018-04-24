using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckSetter : InitializePlayersGameObjects {

    private List<String> importHexList()
    {
        return new List<string>();
    }

    private List<GameObject> CreateHexCards(List<string> hexNames)
    {
        List<GameObject> HexList = new List<GameObject>();
        foreach (var n in hexNames)
        {
             GameObject card = new GameObject(n);
            //add graphics;
            //  - Hex SplashArt
            //  - Hex Unit Model, chyba musi być przenieiony do IHex?
            //  - Grafika domyślna ramki z karty chyba powinna należeć do samego decku/playera a nie do każdej karty
            card.AddComponent<PolygonCollider2D>();
            //find IHex
            //card.AddComponent<IHex>();
            HexList.Add(card);
        }
        return HexList;
    }

    private void setDeckAsParent(GameObject deck, List<GameObject> hexList)
    {
        foreach (var hex in hexList)
        {
            hex.GetComponent<Transform>().SetParent(deck.GetComponent<Transform>());
        }
    }

    public override void Initialize(GameObject Deck)
    {
        List<String> NamesInDeck = importHexList();
        //NamesInDeck.Add("Zielony Brat");
        //NamesInDeck.Add("Leśny Wilk");
        List<GameObject> HexList = CreateHexCards(NamesInDeck);
        setDeckAsParent(Deck, HexList);
    }
}
