using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BrokenMinersCarrier : UnitHex
{
    public override void InitHex()
    {
        this.hexCost = new HexCost(3, 0, 0, 1);
        this.lifePoints = 6;
    }

    public override void MakeActionOnEnter()
    {
        this.changeLifePoints(this, 2);
    }

    public override void MakeActionAtAttack()
    {
        List<UnitHex> gls = getHexUnitsFromContainer("Board");
        foreach( var g in gls)
        {
            this.changeLifePoints(g, 1);
        }
    }
}
