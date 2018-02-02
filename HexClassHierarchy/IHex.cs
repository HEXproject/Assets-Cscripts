using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

public abstract class IHex : MonoBehaviour{

    private string _hexName;
    private HexCost _hexCost;

    public string hexName { get { return _hexName; } set { _hexName = value; } }
    public HexCost hexCost { get { return _hexCost; } set { _hexCost = value; } }

    protected void changeAttackPoints(UnitHex aUnit, int valueToChange)
    {
        aUnit.attackPoints += valueToChange;
        if (aUnit.attackPoints < 0) aUnit.attackPoints = 0;
    }
    protected void changeLifePoints(UnitHex aUnit, int valueToChange)
    {
        aUnit.lifePoints += valueToChange;
        if (aUnit.lifePoints < 0)
        {
            destroyUnit(aUnit);
        }
    }
    protected void changeFaithCost(IHex aUnit, int valueToChange)
    {
        aUnit.hexCost.faithPoints += valueToChange;
        if (aUnit.hexCost.faithPoints < 0) aUnit.hexCost.faithPoints = 0;
    }
    protected void changeCommandCost(IHex aUnit, int valueToChange)
    {
        aUnit.hexCost.commandPoints += valueToChange;
        if (aUnit.hexCost.commandPoints < 0) aUnit.hexCost.commandPoints = 0;
    }
    protected void changeTalentCost(IHex aUnit, int valueToChange)
    {
        aUnit.hexCost.talentPoints += valueToChange;
        if (aUnit.hexCost.talentPoints < 0) aUnit.hexCost.talentPoints = 0;
    }
    protected void changeSpecialCost(IHex aUnit, int valueToChange)
    {
        aUnit.hexCost.specialPoints += valueToChange;
        if (aUnit.hexCost.specialPoints < 0) aUnit.hexCost.specialPoints = 0;
    }
    protected void changeMovement(UnitHex aUnit, int valueToChange)
    {
        aUnit.movement += valueToChange;
        if (aUnit.movement < 0) aUnit.movement = 0;
    }
    
    //todo
    protected void destroyUnit(UnitHex unitToDestroy)
    {
        return;
    }
    //todo
    protected List<UnitHex> getHexUnitsFromContainer(string containerName)
    {
        List<UnitHex> listOfHexes = null;
        GameObject container = this.GetComponent<Transform>().parent.Find(containerName).gameObject;
        if(container != null)
        {
            for(int i = 0; i < container.GetComponent<Transform>().childCount - 1; ++i)
            {
                if(container.GetComponent<Transform>().GetChild(i).GetComponent<UnitHex>()!=null)
                listOfHexes.Add(container.GetComponent<Transform>().GetChild(i).GetComponent<UnitHex>());
            }
        }        
        return listOfHexes;
    }
    protected List<SpellHex> getHexSpellsFromContainer(string containerName)
    {
        List<SpellHex> listOfHexes = null;
        GameObject container = this.GetComponent<Transform>().parent.Find(containerName).gameObject;
        if (container != null)
        {
            for (int i = 0; i < container.GetComponent<Transform>().childCount - 1; ++i)
            {
                if (container.GetComponent<Transform>().GetChild(i).GetComponent<SpellHex>() != null)
                    listOfHexes.Add(container.GetComponent<Transform>().GetChild(i).GetComponent<SpellHex>());
            }
        }
        return listOfHexes;
    }


    //find neighbour hexTiles
    //find neighbour hexUnits

    public abstract void MakeActionOnEnter();
    public abstract void InitHex();

}
