using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {


    public GameObject hexPrefab;

    // Size of hex_map dimensions, not equal to x,y,z positions. Basicly, how many of tiles you have in each direction

    int width = 20;
    int height = 19;
    // We can add random generation here.


    // Geometrical vector casting

    /*
    float xOffset = 0.27f;
    float zOffset = 0.23f;
    */

    // Size-dependent offset TODO.
    float xOffset = 0.27f;
    float zOffset = 0.23f;

    //GetComponent<MeshRenderer>().bounds;

    // Use this for initialization
    void Start () {
		
        for (int x=0; x<width; ++x)
        {
            for (int y = 0; y < height; ++y)
            {
                float xPos = x*xOffset;
                if (y % 2 == 1)
                {
                    xPos += xOffset/2;
                }
                
                //#Optional - map level, random generation
                float random_tile_lvl = Random.Range(-3, 3);
                float z = (float)(random_tile_lvl * 0.05);

                // Creation of the tiles with appropiate X/Y names and map parenting.
                GameObject hex_tile = (GameObject) Instantiate(hexPrefab, new Vector3(xPos, z , y * zOffset), Quaternion.identity);

                // Give Hex the name.
                hex_tile.name = "HEX_" + x + "_" + y;
                // Store the coordinates.
                hex_tile.GetComponent < Hex>().y = y;
                hex_tile.GetComponent<Hex>().z = (int)(z/0.05);
                hex_tile.GetComponent<Hex>().x = x;

                //For a cleaner Hierarchy, parent this hex to the map
                hex_tile.transform.SetParent(this.transform);

                // TODO:
                hex_tile.isStatic = true;

            }
        }


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
