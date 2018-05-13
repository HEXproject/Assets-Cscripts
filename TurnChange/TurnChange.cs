using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnChange : MonoBehaviour
{
    //make it private
    public GameObject _Player1;
    public GameObject _Player2;

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
            _Player1 = player1;
            _Player2 = player2;
        }
        else
        {
            Debug.Log("One or both players were NULL.");
        }
    }
    
    public GameObject GetActivePlayer()
    {
        return _Player1;
    }
    public GameObject GetInactivePlayer()
    {
        return _Player2;
    }

    void Start()
    {
        SpawnUnitsThatStartsOnBoard();
        StartCoroutine(PlanningPhase());
    }

    IEnumerator Round()
    {
        StartCoroutine(PlanningPhase());
        StartCoroutine(ActionPhase());
        makeAllNotExhausted(_Player1, _Player2);
        StartCoroutine(Round());
        yield return new WaitForSeconds(1);
    }

    IEnumerator PlanningPhase()
    {
        StartCoroutine(PlanningPhaseByPlayer(_Player1));
        //turn indicator goes further
        yield return new WaitForSeconds(1);
        StartCoroutine(PlanningPhaseByPlayer(_Player2));
        //turn indicator goes further
        yield return new WaitForSeconds(1);
    }

    IEnumerator ActionPhase()
    {
        StartCoroutine(ActionPhaseByPlayer(_Player1));
        yield return new WaitForSeconds(1);
        //turn indicator goes on
        StartCoroutine(ActionPhaseByPlayer(_Player2));
        yield return new WaitForSeconds(1);
        //turn indicatio goes on
        if (areAllExhausted(_Player1) && areAllExhausted(_Player2) == false) StartCoroutine(ActionPhase());
    }

    void makeAllNotExhausted(GameObject p1, GameObject p2)
    {
        
    }
    bool areAllExhausted(GameObject player)
    {
        return false;
    }

    IEnumerator PlanningPhaseByPlayer(GameObject player)
    {
        //increase mana
        //draw card
        //increase mana
        yield return new WaitForSeconds(_basicCountOfPlanningPhase);
        GameObject chosenHex = getChosenHex();
        GameObject tile = getPosition();
        if (chosenHex != null && tile != null)
        {
            //add position to entering
            chosenHex.GetComponent<IHex>().EnterOnSpecifiedTile(tile);
            yield return new WaitForSeconds(1);
        }
    }

    GameObject getChosenHex()
    {
        return new GameObject();
    }
    GameObject getPosition()
    {
        return new GameObject();
    }

    IEnumerator ActionPhaseByPlayer(GameObject player)
    {
        yield return new WaitForSeconds(_basicTimeOfActionPhase);
        GameObject chosenUnit = getChosenActiveUnit();
        //add possibility to use special skill
        GameObject chosenTarget = getChosenTarget();
        if (chosenUnit != null && chosenTarget != null)
        {
            chosenUnit.GetComponent<UnitHex>().Attack(chosenTarget);
            yield return new WaitForSeconds(1);
        }
    }

    private GameObject getChosenTarget()
    {
        return new GameObject();
    }

    private GameObject getChosenActiveUnit()
    {
        return new GameObject();
    }


    void SpawnUnitsThatStartsOnBoard()
    {
        

    }
}
