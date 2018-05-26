using UnityEngine;

namespace Assets.TurnChange
{
    public class TurnChangeEvents : MonoBehaviour {

        public delegate void ChangingTurn();
        public static event ChangingTurn EndOfTurn;
        public static event ChangingTurn NextPhase;
        public static event ChangingTurn StartIt;

        public static void TurnHasEnded()
        {
            //drawHex
            if (EndOfTurn != null)
            {
                EndOfTurn();
            }
        }

        public static void StartOfTheGame()
        {
            if (StartIt != null)
            {
                StartIt();
            }
        }
        public static void DoPhase()
        {
            //drawHex
            if (NextPhase != null)
            {
                NextPhase();
            }
        }

    }
}
