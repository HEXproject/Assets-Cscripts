using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelA : MonoBehaviour {

    // Use this for initialization
    public Transform prefab;

    


    public static PanelA instance;
    public int currentState = 0;
    public int[] stateArray = new int[30];
    void Start () {
        GameObject go = GameObject.Find("Indicator");
        prefab = (Transform)go.GetComponent(typeof(Transform));
    }
	
	// Update is called once per frame
	void Update () {
		

	}
    public void Makenew()
    {
        currentState++;
             var xd = Instantiate(prefab, new Vector3(815, currentState* -80, 930), Quaternion.identity);
        xd.tag = "clone";


    }
}
