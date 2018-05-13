using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour {

    #region MapPresets

    //Basic Tile
    public GameObject PrefabHexTile;
    public Material[] HexMaterials;
    public int mapSize = 10;

    #endregion


    // Use this for initialization
    void Start () {

        GenerateMap();

    }
	



    // Update is called once per frame
    void Update () {
		
    }


    public void GenerateMap()

    {

        Vector3 pos = Vector3.zero;

        for (int q = -mapSize; q <= mapSize; q++)
        {
            int r1 = Mathf.Max(-mapSize, -q - mapSize);
            int r2 = Mathf.Min(mapSize, -q + mapSize);

            for (int r = r1; r <= r2; r++)
            {
                pos.x = 3.0f / 2.0f * q;
                pos.z = Mathf.Sqrt(3.0f) * (r + q / 2.0f);

                Hex hex = new Hex(q, r);
                GameObject hexGO = (GameObject)Instantiate(PrefabHexTile, pos, Quaternion.identity, this.transform);
                hexGO.name = "HEX_" + q + "_" + r + "_" + -(q + r);
                MeshRenderer HexMR = hexGO.GetComponentInChildren<MeshRenderer>();
                HexMR.material = HexMaterials[Random.Range(0, HexMaterials.Length)];

            }

        }


        StaticBatchingUtility.Combine(this.gameObject);

    }


}




#region InspectorSettings

public enum MapShape
{
    Rectangle,
    Hexagon,
    Parrallelogram,
    Triangle
}

[System.Serializable]
public enum HexOrientation
{
    Pointy,
    Flat
}


#endregion