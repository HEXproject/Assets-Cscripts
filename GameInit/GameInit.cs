using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameInit : MonoBehaviour
{
    public GameObject TheGame;
    
    private void Start()
    {
        //need to relocate those lines to smaller functions
        TheGame = new GameObject("TheGame");

        GameObject Board = new GameObject("Board");
        GameObject Turn = new GameObject("Turn");
        GameObject Player1 = new GameObject("Player1");
        GameObject Player2 = new GameObject("Player2");

        Board.GetComponent<Transform>().SetParent(TheGame.GetComponent<Transform>());
        Turn.GetComponent<Transform>().SetParent(TheGame.GetComponent<Transform>());
        Player1.GetComponent<Transform>().SetParent(TheGame.GetComponent<Transform>());
        Player2.GetComponent<Transform>().SetParent(TheGame.GetComponent<Transform>());

        GameObject Map = new GameObject("Map");
        GameObject Player1UserInterface = new GameObject("UI");
        GameObject Player2UserInterface = new GameObject("UI");

        //Map.AddComponent<MapGeneration>();
        Turn.AddComponent<TurnChange>();
        //make it to event
        Turn.GetComponent<TurnChange>().SetPlayers(Player1, Player2);
        Turn.GetComponent<TurnChange>().SetTurnToPhaseByName("ActionPhase");

        Map.GetComponent<Transform>().SetParent(Board.GetComponent<Transform>());
        Player1UserInterface.GetComponent<Transform>().SetParent(Player1.GetComponent<Transform>());
        Player2UserInterface.GetComponent<Transform>().SetParent(Player2.GetComponent<Transform>());

        GameObject UI1Background = new GameObject("Background");
        GameObject UI2Background = new GameObject("Background");
        GameObject UI1Deck = new GameObject("Deck");
        GameObject UI2Deck = new GameObject("Deck");
        GameObject UI1Hand = new GameObject("Hand");
        GameObject UI2Hand = new GameObject("Hand");

        UI1Background.GetComponent<Transform>().SetParent(Player1UserInterface.GetComponent<Transform>());
        UI1Deck.GetComponent<Transform>().SetParent(Player1UserInterface.GetComponent<Transform>());
        UI1Hand.GetComponent<Transform>().SetParent(Player1UserInterface.GetComponent<Transform>());
        UI2Background.GetComponent<Transform>().SetParent(Player2UserInterface.GetComponent<Transform>());
        UI2Deck.GetComponent<Transform>().SetParent(Player2UserInterface.GetComponent<Transform>());
        UI2Hand.GetComponent<Transform>().SetParent(Player2UserInterface.GetComponent<Transform>());

    }
    

}
