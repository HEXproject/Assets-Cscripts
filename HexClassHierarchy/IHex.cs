using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

public abstract class IHex : MonoBehaviour{

    private string _hexName;
    private HexCost _hexCost;
    private List<string> _hexTags;
    private string _hexDescription;

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
    
    protected void destroyUnit(UnitHex unitToDestroy)
    {
        GameObject hexContainer = getHexContainer("/Main Camera/HexUI/Graveyard");
        unitToDestroy.GetComponent<Transform>().parent.gameObject.GetComponent<Transform>().SetParent(null);
        unitToDestroy.GetComponent<Transform>().parent.gameObject.GetComponent<Transform>().position = hexContainer.GetComponent<Transform>().position;
        unitToDestroy.GetComponent<Transform>().parent.gameObject.GetComponent<Transform>().SetParent(hexContainer.GetComponent<Transform>());
        return;
    }

    //better move to other class
    protected GameObject getHexContainer(string hexContainerName)
    {
        return this.GetComponent<Transform>().parent.Find(hexContainerName).gameObject; 
    }
    
    protected List<IHex> getHexByTypeFromContainer(GameObject hexContainer, string hexType)
    {
        List<IHex> listOfHexes = new List<IHex>();
        if(hexContainer == null)
        {
            Debug.Log("hexContainer == null");
            return null;
        }
        else
        {
            for(int i = 0; i < hexContainer.GetComponent<Transform>().childCount - 1; ++i)
            {
                if(hexContainer.GetComponent<Transform>().GetChild(i).GetComponent<IHex>()!=null 
                    && hexContainer.GetComponent<Transform>().GetChild(i).GetComponent<IHex>().GetType().Name==hexType)
                listOfHexes.Add(hexContainer.GetComponent<Transform>().GetChild(i).GetComponent<IHex>());
            }
        }        
        return listOfHexes;
    }
    
    protected List<IHex> getHexByTagFromIHexList(List<IHex> IhexList, string tags)
    {
        List<IHex> listOfIHexWithProperTag = new List<IHex>();
        for(int i = IhexList.Count-1; i >= 0; --i)
        {
            foreach(var t in IhexList[i]._hexTags)
            {
                if(t == tags)
                {
                    listOfIHexWithProperTag.Add(IhexList[i]);
                    break;
                }
            }
        }
        return listOfIHexWithProperTag;
    }

    //find neighbour hexTiles
    //find neighbour hexUnits

    public abstract void MakeActionOnEnter();
    public abstract void InitHex();

}
