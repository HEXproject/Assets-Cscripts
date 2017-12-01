using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToRemove : MonoBehaviour {



    private void OnMouseOver()
    
    {
        if (Input.GetMouseButtonDown(0))
        {

            this.GetComponent<Transform>().Find("/Main Camera/HexUI/RemoveButton")
                    .GetComponent<DeleteButton>().toDelete = this.gameObject;
        }
        if (Input.GetMouseButtonDown(1))
        {
            this.GetComponent<Transform>().Find("/Main Camera/HexUI").GetComponent<MovingObject>().
                 mulliganHex = this.gameObject;
            this.GetComponent<Transform>().Find("/Main Camera/HexUI").GetComponent<MovingObject>().
                domulligan = true;
        }
    }
    
}
