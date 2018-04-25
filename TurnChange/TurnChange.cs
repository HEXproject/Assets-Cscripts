using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class TurnChange : MonoBehaviour
{
    //make it private
    public GameObject _activePlayer;
    public GameObject _inactivePlayer;

    public GameObject wolf;
    public GameObject carrier1;
    public GameObject carrier2;

    void OnEnable()
    {

        TurnChangeEvents.EndOfTurn += GoToNextPhase;
        TurnChangeEvents.NextPhase += DoPhase;
    }
    void OnDisable()
    {
        TurnChangeEvents.EndOfTurn -= GoToNextPhase;
        TurnChangeEvents.NextPhase -= DoPhase;
    }

    public string _typeOfPhase;

    //finishPhasesTimers
    public float _basicTimeOfPlanningPhase = 10f;
    public float _basicTimeOfActionPhase = 15f;
    public float _remainingTime = 0f;

    public int _basicCountOfPlanningPhase = 5;
    public int _basicCountOfActionPhase = 4;
    public int _remainingPlanningPhases = 0;
    public int _remainingActionPhases = 0;

    public void SetPlayers(GameObject player1, GameObject player2)
    {
        if (player1 != null && player2 != null)
        {
            _activePlayer = player1;
            _inactivePlayer = player2;
        }
        else
        {
            Debug.Log("One or both players were NULL.");
        }
    }
    private void SwitchPlayers()
    {
        GameObject tmp = _activePlayer;
        _activePlayer = _inactivePlayer;
        _inactivePlayer = tmp;

        _inactivePlayer.SetActive(false);
        _activePlayer.SetActive(true);
    }

    public GameObject GetActivePlayer()
    {
        return _activePlayer;
    }
    public GameObject GetInactivePlayer()
    {
        return _inactivePlayer;
    }

    public void SetTurnToPhaseByName(string phaseName)
    {
        if (phaseName == "PlanningPhase" || phaseName == "ActionPhase")
        {
            _typeOfPhase = phaseName;
        }
        else
        {
            Debug.Log("Incorrect phase name");
        }
    }
    private void ReduceRemainingPhaseCounter(string phaseName)
    {
        if (phaseName == "ActionPhase")  _remainingPlanningPhases--;
        if (phaseName == "PlanningPhase")  _remainingActionPhases--;
    }
    private void GoToNextPhase()
    {
        SwitchPlayers();
        ReduceRemainingPhaseCounter(_typeOfPhase);
        if (_remainingPlanningPhases == 0)
        {
            _remainingPlanningPhases = _basicCountOfPlanningPhase;
            SetTurnToPhaseByName("ActionPhase");
        }
        else if (_remainingActionPhases == 0)
        {
            _remainingActionPhases = _basicCountOfActionPhase;
            SetTurnToPhaseByName("PlanningPhase");
        }
    }
    private void DoPlanningPhase()
    {
        // Send event to draw a card
        // Send event to choose hex
        bool tmpIsHexChosen = false;
        if (tmpIsHexChosen)
        {
            GameObject chosenCard = new GameObject();
            //chosenCard = getChosenCard();
            //should I chceck if IHex is null?
            chosenCard.GetComponent<IHex>().MakeActionOnEnter();

            GoToNextPhase();
        }
        else
        {
            Debug.Log("Chosen Hex is null, can't going forward with turn");
        }
    }
    private void DoActionPhase()
    {
        // Send event to choose board unit
        bool tmpIsBoardUnitChosen = false;
        if (tmpIsBoardUnitChosen)
        {
            GameObject chosenCard = new GameObject();
            //chosenCard = getChosenCard();
            //should I chceck if IHex is null?
            //chosenCard.GetComponent<UnitHex>().MakeActionAtAttack();

            GoToNextPhase();
        }
    }
    public void DoPhase()
    {
        if(_typeOfPhase == "PlanningPhase") DoPlanningPhase();
        else if (_typeOfPhase == "ActionPhase") DoActionPhase();
    }

    void Start()
    {
        spawnUnits();
        StartCoroutine(PlanningPhase());
    }

    IEnumerator PlanningPhase()
    {
        Debug.Log("Planning phase has just started! " + _activePlayer);
        Debug.Log("Gained Full Mana Crystal! " + _activePlayer.ToString());
        yield return new WaitForSeconds(2);
        Debug.Log("Drawn card! " + _activePlayer.ToString());
        yield return new WaitForSeconds(2);
        Debug.Log("Gain Full Mana Crystal!" + _activePlayer.ToString());
        wolf.GetComponent<UnitHex>().isExhausted = false;
        carrier1.GetComponent<UnitHex>().isExhausted = false;
        carrier2.GetComponent<UnitHex>().isExhausted = false;
        Debug.Log("recharged units");

        _remainingPlanningPhases++;
        SwitchPlayers();
        StartCoroutine(realActionPhase());


    }

    IEnumerator realActionPhase()
    {
        Debug.Log("Action phase has just started! " + _activePlayer);
        StartCoroutine(ActionPhase(wolf, carrier1));
        StartCoroutine(ActionPhase(carrier1, wolf));
        StartCoroutine(ActionPhase(carrier2, wolf));
        if (_remainingPlanningPhases < _basicCountOfPlanningPhase)
        {
            StartCoroutine(PlanningPhase());
        }
        else Debug.Log("end of game");
        yield return new WaitForSeconds(1);
    }

    IEnumerator ActionPhase(GameObject unit, GameObject target)
    {
        Debug.Log("Unit: " + unit + " has attacked!");
        unit.GetComponent<UnitHex>().MakeActionAtAttack(target);
        Debug.Log("target " + target + " hp after attack: " + target.GetComponent<UnitHex>().lifePoints);
        yield return new WaitForSeconds(2);
    }


    void spawnUnits()
    {
        wolf = new GameObject("wolf");
        carrier1 = new GameObject("carrier1");
        carrier2 = new GameObject("carrier2");

        wolf.AddComponent<FernWolf>();
        carrier1.AddComponent<BrokenMinersCarrier>();
        carrier2.AddComponent<BrokenMinersCarrier>();

        wolf.GetComponent<UnitHex>().InitHex();
        carrier1.GetComponent<UnitHex>().InitHex();
        carrier2.GetComponent<UnitHex>().InitHex();

    }
}
