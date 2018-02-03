using UnityEngine;
using System.Collections;

public class HexCost
{
    private int _commandPoints;
    private int _talentPoints;
    private int _faithPoints;
    private int _specialPoints;

    public int commandPoints { get { return _commandPoints; } set { _commandPoints = value; } }
    public int talentPoints { get { return _talentPoints; } set { _talentPoints = value; } }
    public int faithPoints { get { return _faithPoints; } set { _faithPoints = value; } }
    public int specialPoints { get { return _specialPoints; } set { _specialPoints = value; } }

    public HexCost(int commandPoints,int talentPoints, int faithPoints, int specialPoints)
    {
        _commandPoints = commandPoints;
        _talentPoints = talentPoints;
        _faithPoints = faithPoints;
        _specialPoints = specialPoints;
    }

}
