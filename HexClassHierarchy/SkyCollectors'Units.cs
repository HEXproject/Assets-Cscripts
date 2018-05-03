using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BrokenMinersCarrier : UnitHex
{
    public override void InitHex()
    {
        this.hexCost = new HexCost(3, 0, 0, 1);
        this.attackPoints = 1;
        this.lifePoints = 6;
    }

    public override void EnterOnSpecifiedTile(GameObject tile)
    {
        this.changeLifePoints(this, -4);
    }

    public override void Attack(GameObject target)
    {
        target.GetComponent<UnitHex>().lifePoints -= attackPoints;
    }
    public override void Die()
    {

    }
}
