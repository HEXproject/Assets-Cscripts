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
        GameObject deck = getHexContainer("/Main Camera/HexUI/Deck");
        string hexType = "SpellHex";
        string hexTag = "BoostSpell";
        List<IHex> spellsWithTag = getHexByTypeFromContainer(deck, hexType);
        spellsWithTag = getHexByTagFromIHexList(spellsWithTag, hexTag);
        foreach(var s in spellsWithTag)
        {
            s.hexCost.specialPoints -= 1;
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
        //not ready :(
    }
}
