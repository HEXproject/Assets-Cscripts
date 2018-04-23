﻿using System.Collections;
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

        SetPlayerChildhood(Player1);
        SetPlayerChildhood(Player2);

        GameObject Map = new GameObject("Map");

        //Map.AddComponent<MapGeneration>();
        Turn.AddComponent<TurnChange>();
        //make it to event
        Turn.GetComponent<TurnChange>().SetPlayers(Player1, Player2);
        Turn.GetComponent<TurnChange>().SetTurnToPhaseByName("ActionPhase");

        Map.GetComponent<Transform>().SetParent(Board.GetComponent<Transform>());

    }

    void SetPlayerChildhood(GameObject player)
    {
        GameObject Deck = new GameObject("Deck");
        GameObject Hand = new GameObject("HandSetter");
        GameObject Portrait = new GameObject("PortraitSetter");
        GameObject Graveyard = new GameObject("GraveyardSetter");

        Deck.GetComponent<Transform>().SetParent(player.GetComponent<Transform>());
        Hand.GetComponent<Transform>().SetParent(player.GetComponent<Transform>());
        Portrait.GetComponent<Transform>().SetParent(player.GetComponent<Transform>());
        Graveyard.GetComponent<Transform>().SetParent(player.GetComponent<Transform>());

        SetDeck(Deck);
        SetHand(Hand);
        SetPortrait(Portrait);
        SetGraveyard(Graveyard);

    }
    
    private void SetGraveyard(GameObject graveyard)
    {
        graveyard.AddComponent<GraveyardSetter>();
        //graveyard.GetComponent<GraveyardSetter>().SetMe(graveyard);
        Destroy(graveyard.GetComponent<GraveyardSetter>());
    }

    private void SetPortrait(GameObject portrait)
    {
        portrait.AddComponent<PortraitSetter>();
        //portrait.GetComponent<PortraitSetter>().SetMe(portrait);
        Destroy(portrait.GetComponent<PortraitSetter>());
    }

    private void SetHand(GameObject hand)
    {
        hand.AddComponent<HandSetter>();
        //hand.GetComponent<HandSetter>().SetMe(hand);
        Destroy(hand.GetComponent<HandSetter>());
    }

    private void SetDeck(GameObject deck)
    {
        deck.AddComponent<DeckSetter>();
        deck.GetComponent<DeckSetter>().SetMe(deck);
        Destroy(deck.GetComponent<DeckSetter>());
    }

}
