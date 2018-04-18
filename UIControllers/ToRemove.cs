using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToRemove : MonoBehaviour {



    private void OnMouseOver()
    
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.GetComponent<MovingCards>().toChange = !this.GetComponent<MovingCards>().toChange;
            
        }
    }
    
}
