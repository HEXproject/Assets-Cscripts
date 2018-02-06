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
        this.changeLifePoints(this, -4);
    }

    public override void MakeActionAtAttack()
    {
        GameObject deck = getHexContainer("/Main Camera/HexUI/Deck");
        string hexType = "UnitHex";
        List<IHex> gls = getHexByTypeFromContainer(deck, hexType);
        
        foreach( var g in gls)
        {
            this.changeLifePoints((UnitHex)g, -21);
        }
    }
}
