using System.Collections.Generic;
using UnityEngine;

namespace Assets.GameInit
{
    public class DeckSetter : InitializePlayersGameObjects {

        private List<string> ImportHexList()
        {
            return new List<string>();
        }

        private IEnumerable<GameObject> CreateHexCards(List<string> hexNames)
        {
            var hexList = new List<GameObject>();
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
                hexList.Add(card);
            }
            return hexList;
        }

        private void SetDeckAsParent(GameObject deck, IEnumerable<GameObject> hexList)
        {
            foreach (var hex in hexList)
            {
                hex.GetComponent<Transform>().SetParent(deck.GetComponent<Transform>());
            }
        }

        public override void Initialize(GameObject deck)
        {
            var namesInDeck = ImportHexList();
            //NamesInDeck.Add("Zielony Brat");
            //NamesInDeck.Add("Leśny Wilk");
            var hexList = CreateHexCards(namesInDeck);
            SetDeckAsParent(deck, hexList);
        }
    }
}
