﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

public abstract class UnitHex : IHex
{
    public bool isExhausted;

    public int lifePoints { get; set; }
    public int attackPoints { get; set; }
    public HexCost cost { get; set; }
    public int movement { get; set; }
    public int lifeTime { get; set; }

    public abstract void MakeActionAtAttack(GameObject target);

}
