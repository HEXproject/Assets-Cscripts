using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInit : MonoBehaviour
{
    public GameObject TheGame;
    
    private void Start()
    {
        TheGame = new GameObject("TheGame");

        GameObject Board = new GameObject("Board");
        GameObject Turn = new GameObject("Turn");
        GameObject Player1 = new GameObject("Player1");
        GameObject Player2 = new GameObject("Player2");

        Board.GetComponent<Transform>().SetParent(TheGame.GetComponent<Transform>());
        Turn.GetComponent<Transform>().SetParent(TheGame.GetComponent<Transform>());
        Player1.GetComponent<Transform>().SetParent(TheGame.GetComponent<Transform>());
        Player2.GetComponent<Transform>().SetParent(TheGame.GetComponent<Transform>());



    }

}
