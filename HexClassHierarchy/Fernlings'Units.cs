using UnityEngine;
using System.Collections;
using System;

public class FernWolf : UnitHex
{
    public override void InitHex()
    {
        this.hexCost = new HexCost(0, 1, 1, 2);
        this.attackPoints = 4;
        this.lifePoints = 10;
    }
    public override void MakeActionOnEnter()
    {

    }
    public override void MakeActionAtAttack(GameObject target)
    {
        target.GetComponent<UnitHex>().lifePoints -= attackPoints;
    }
}
