using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventEx : MonoBehaviour {

    public delegate void EventHandler();
    public static event EventHandler BeginningOfPlanningPhase;
    public static event EventHandler BeginningOfActionPhase;

    public static void GoToPlanningPhase()
    {
        //drawHex
        if (BeginningOfPlanningPhase != null)
        {
            BeginningOfPlanningPhase();
        }
    }
    public static void GoToActionPhase()
    {
        //drawHex
        if (BeginningOfActionPhase != null)
        {
            BeginningOfActionPhase();
        }
    }

}
