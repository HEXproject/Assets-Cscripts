using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Director;

public class TurnChange : MonoBehaviour
{
    private GameObject _activePlayer;
    private GameObject _inactivePlayer;

    private string _typeOfPhase;

    //finishPhasesTimers
    private float _basicTimeOfPlanningPhase = 10f;
    private float _basicTimeOfActionPhase = 15f;
    private float _remainingTime = 0f;

    private int _basicCountOfPlanningPhase = 4;
    private int _basicCountOfActionPhase = 4;
    private int _remainingPlanningPhases = 0;
    private int _remainingActionPhases = 0;

    public void SetPlayers(GameObject player1, GameObject player2)
    {
        if (player1 != null && player2 != null)
        {
            _activePlayer = player1;
            _inactivePlayer = player2;
        }
        else
        {
            Debug.Log("Got null as player/players");
        }
    }
    private void SwitchPlayers()
    {
        GameObject tmp = _activePlayer;
        _activePlayer = _inactivePlayer;
        _inactivePlayer = tmp;
        Destroy(tmp);

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
        //_activePlayer.GetComponent<Transform>().FindChild("Deck").DrawCard(1);
        ////wait for player to choose proper card to play
        //GameObject chosenCard = getChosenCard(); //get card chosen by player
        //chosenCard.Play(); //move to board, use 3d model, makeActionOnEnter()
        GoToNextPhase();
    }
    private void DoActionPhase()
    {
        ////wait for player to choose proper unit to make action
        //GameObject chosenUnit = getChosenUnit(); //get unit chosen by player
        //chosenUnit.GetComponent<UnitHex>().MakeActionAtAttack(); //makeActionOnAttack();
        GoToNextPhase();
    }
    public void DoPhase()
    {
        if(_typeOfPhase == "PlanningPhase") DoPlanningPhase();
        else if (_typeOfPhase == "ActionPhase") DoActionPhase();
    }



}
