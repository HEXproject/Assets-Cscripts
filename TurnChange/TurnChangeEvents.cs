using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnChangeEvents : MonoBehaviour {

    public delegate void EventHandler();
    public static event EventHandler EndOfTurn;
    public static event EventHandler NextPhase;

    public static void GoToNextPhase()
    {
        //drawHex
        if (EndOfTurn != null)
        {
            EndOfTurn();
        }
    }

    public static void DoPhase()
    {
        //drawHex
        if (EndOfTurn != null)
        {
            EndOfTurn();
        }
    }

}
