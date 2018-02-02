using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SteamHaze : SpellHex
{
    public override void MakeActionOnEnter()
    {
        //isn't this an easier way to declare functions? idk
        List<UnitHex> gls = getTargets();
        foreach(var g in gls)
        {
            g.feetSpeed += 1;
        }
    }
}

public class OilExplosion : SpellHex
{
    public override void MakeActionOnEnter()
    {
        //need to find better way to find neighbours and execute functions from UnitHex objects.
        UnitHex oilCan = getTarget();
        List<UnitHex> oilCanNeighbours = getTargets();
        foreach(var n in oilCanNeighbours)
        {
            this.reduceLifePoints(n, 3);
        }
    }
}
