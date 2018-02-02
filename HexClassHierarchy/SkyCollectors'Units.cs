using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BrokenMinersCarrier : UnitHex
{
    public override void setBaseStats()
    {
        this.lifePoints = 6;
        this.faithPoints = 4;
    }

    public override void MakeActionOnEnter()
    {
        setBaseStats();
        this.reduceLifePoints(this, 2);
    }

    public override void MakeActionAtAttack()
    {
        List<UnitHex> gls = getTargets();
        foreach( var g in gls)
        {
            this.reduceLifePoints(g, 1);
        }
    }
}
