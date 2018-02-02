using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

public abstract class UnitHex : IHex
{
    private int _lifePoints;
    private int _faithPoints;

    public int lifePoints { get { return _lifePoints; } set { _lifePoints = value; } }
    public int faithPoints { get { return _faithPoints; } set { _faithPoints = value; } }

    public abstract void setBaseStats();

}
