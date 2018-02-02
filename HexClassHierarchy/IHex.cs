using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

public abstract class IHex : MonoBehaviour{

    private string _hexName;
    private int _hexCost;

    public string hexName { get { return _hexName; } set { _hexName = value; } }
    public int hexCost { get { return _hexCost; } set { _hexCost = value; } }

    protected void reduceLifePoints(UnitHex aUnit, int valueToReduce)
    {
        aUnit.lifePoints -= valueToReduce;
        //if (aUnit.lifePoints < 0)
        //{
        //    //returnToBaseStats(aUnit);
        //    //moveToGravyard(aUnit);
        //}
    }

    protected void reduceFaithPoints(UnitHex aUnit, int valueToReduce)
    {
        aUnit.faithPoints -= valueToReduce;
        //if (aUnit.lifePoints < 0)
        //{
        //    //unitGoesInsane();
        //}
    }

    protected UnitHex getTarget()
    {
        UnitHex g = null;
        //get gameObjectThatPlayerIsClickingAt
        return g;
    }
    protected List<UnitHex> getTargets()
    {
        List<UnitHex> gls = null;
        //get list of game objects;
        return gls;
    }

    //find neighbour hexTiles
    //find neighbour hexUnits

    //private void reduceEnergyPoints(UnitHex aUnit, int valueToReduce)


    //private void destroyHex(IHex h) { }

    public abstract void MakeActionOnEnter();


}
