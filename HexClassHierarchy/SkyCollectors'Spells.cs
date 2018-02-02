using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SteamHaze : SpellHex
{
    public override void InitHex()
    {
        this.hexCost = new HexCost(0, 1, 0, 1);
    }
    public override void MakeActionOnEnter()
    {
        List<UnitHex> gls = getHexUnitsFromContainer("Deck");
        foreach(var g in gls)
        {
            this.changeMovement(g, 1);
        }
    }
}
public class OldGrease:SpellHex
{
    public override void InitHex()
    {
        this.hexCost = new HexCost(0, 0, 0, 2);
    }
    public override void MakeActionOnEnter()
    {
        List<UnitHex> deckUnits = getHexUnitsFromContainer("Deck");
        List<SpellHex> deckSpells = getHexSpellsFromContainer("Deck");
        foreach(var u in deckUnits)
        {
            this.changeFaithCost(u, 1);
        }
        foreach(var s in deckSpells)
        {
            this.changeFaithCost(s, 1);
        }

    }
}
public class OilExplosion : SpellHex
{
    public override void InitHex()
    {
        this.hexCost = new HexCost(0, 0, 0, 1);
    }
    public override void MakeActionOnEnter()
    {
        //UnitHex oilCan = getHexUnitsFromContainer("Board");
        //List<UnitHex> oilCanNeighbours = getHexUnitsFromContainer();
        //foreach(var n in oilCanNeighbours)
        //{
            //this.changeLifePoints(n, -3);
        //}
    }
}
