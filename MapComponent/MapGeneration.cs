using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour {



    public GameObject PrefabHexTile;

    //Size of the map in terms of hex times number
    //Not representative to UNITY lenght units
    public int width =20;          //To be replaced
    public int height =20;         // To be replaced

    // Size-dependent offset TODO.
    float yOffset = 0.78f;
    float xOffset = 0.9f;

	// Use this for initialization
	void Start () {

     for (int x=0; x<width; x++)
        {
        for (int y=0; y<height; y++)
            {
                float xPos = x * xOffset;
                if (y % 2 == 1)
                {
                    xPos += xOffset / 2;
                }

                // Creation of the tiles with appropiate X/Y names and map parenting.
                GameObject hex_tile = (GameObject)Instantiate(PrefabHexTile, new Vector3(xPos, 0, y * yOffset), Quaternion.identity);

                // Give Hex the name.
                hex_tile.name = "HEX_" + x + "_" + y;

                /*
                
                // Store the coordinates.
                hex_tile.GetComponent<Hex>().y = y;
                hex_tile.GetComponent<Hex>().z = 0;
                hex_tile.GetComponent<Hex>().x = x;
                
                // TODO:
                hex_tile.isStatic = true;

                */

                //For a cleaner Hierarchy, parent this hex to the map
                hex_tile.transform.SetParent(this.transform);



            }


        }


		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
