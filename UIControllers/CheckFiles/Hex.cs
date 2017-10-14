using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour {

    // Coordinates of our tile-based behaviour
	public int x;
    public int y;
    public int z;


    public Hex[] GetNeighbours()
    {
        //Each of the hexes has 6 neighbours
        //Neighbour calculation differs and depends on hex position on the map. Odd rows use different algorithm then even.


        // Left and right use in both situations same functions.
        // Left Neighbour.
        GameObject LeftNeighbour = GameObject.Find("HEX_" + (x - 1) + "_" + y);

        // Right Neighbour.
        GameObject RightNeighbour = GameObject.Find("HEX_" + (x + 1) + "_" + y);

        if (y%2 == 1)
        {
                // TopLeft Neighbour.
                GameObject TopLeftNeighbour = GameObject.Find("HEX_" + (x) + "_" + (y + 1));

                // TopRight Neighbour.
                GameObject TopRightNeighbour = GameObject.Find("HEX_" + (x + 1) + "_" + (y + 1));

                // BottomLeft Neighbour.
                GameObject BottomLeftNeighbour = GameObject.Find("HEX_" + (x) + "_" + (y-1));

                // BottomRight Neighbour.
                GameObject BottomRightNeighbour = GameObject.Find("HEX_" + (x + 1) + "_" + (y-1));
        }
        else

        {
            // TopLeft Neighbour.
            GameObject TopLeftNeighbour = GameObject.Find("HEX_" + (x-1) + "_" + (y + 1));

            // TopRight Neighbour.
            GameObject TopRightNeighbour = GameObject.Find("HEX_" + (x) + "_" + (y + 1));

            // BottomLeft Neighbour.
            GameObject BottomLeftNeighbour = GameObject.Find("HEX_" + (x-1) + "_" + (y - 1));

            // BottomRight Neighbour.
            GameObject BottomRightNeighbour = GameObject.Find("HEX_" + (x) + "_" + (y - 1));


        }


        return null;
    }

}
