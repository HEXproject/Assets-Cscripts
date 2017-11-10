using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseOverHex : MonoBehaviour {

    bool mouseOver = false;
    
    void OnMouseEnter()
    {
        mouseOver = true;
        GetComponent<Renderer>().material.SetColor("_Color", Color.black);
        GetComponent<Renderer>().transform.localScale = new Vector3 (0.7f, 0.7f, 1);
    }
    
    void OnMouseExit ()
    {
        mouseOver = false;
        GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        GetComponent<Renderer>().transform.localScale = new Vector3(0.5f, 0.5f, 1);
    }    

}
