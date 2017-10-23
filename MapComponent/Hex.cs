using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex
{
    // Q+R+S=0;
    // S=-(Q+R);

    public Hex(int q, int r)
    {
        this.Q = q;
        this.R = r;
        this.S = -(q + r);
    }


    public readonly int Q; //Column
    public readonly int R; // Row
    public readonly int S; //Sphere row

    public float radius = 1f;
    static readonly float WIDTH_MULTIPLIER = Mathf.Sqrt(3) / 2;

    public Vector3 Position()
    {
        return new Vector3(HexHorizontalSpacing() * (this.Q + this.R / 2f), 0, HexVerticalSpacing() * this.R);

    }

    public float HexHeight()
    {
        return radius * 2;
    }
    public float HexWidth()
    {
        return WIDTH_MULTIPLIER * HexHeight();
    }

    public float HexVerticalSpacing()
    {
        return HexHeight() * 0.75f * 1.025f;
    }

    public float HexHorizontalSpacing()
    {
        return HexWidth() * 1.025f;

    }




}


