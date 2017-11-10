using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawOnClick : MonoBehaviour {

    bool onmouseover = false;
    private void OnMouseDown()
    {
        this.GetComponent<Transform>().Find("/Main Camera/HexUI").GetComponent<MovingObject>().ActualNumberToDraw++;
    }
    
}
