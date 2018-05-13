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
    public override void EnterOnSpecifiedTile(GameObject tile)
    {

    }
    public override void Attack(GameObject target)
    {
        target.GetComponent<UnitHex>().lifePoints -= attackPoints;
    }

    public override void Die()
    {
        
    }
}
