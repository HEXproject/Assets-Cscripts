using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour
{




    // Use this for initialization
    void Start()
    {

    }
    public GameObject LastHitObject;
    int a = 0;

    // Update is called once per frame
                       void Update()
                       {
                   
                           Ray MouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                           RaycastHit hitInfo;
                   
                   
                           // Lets check if we are over UI element or Game Object
                   
                           if (EventSystem.current.IsPointerOverGameObject())
                           {
                               return;
        }


        if (Physics.Raycast(MouseRay, out hitInfo))

        { 


            GameObject OurHitObject = hitInfo.collider.transform.parent.gameObject;
            
            if(OurHitObject.GetComponent<Hex>() != null )
            {
                MouseOver_Hex(OurHitObject);

            }
            


        }
    }



    void MouseOver_Hex(GameObject OurHitObject)

    {
        Debug.Log("Raycast hit" + OurHitObject.name);

        MeshRenderer ActiveTile = OurHitObject.GetComponentInChildren<MeshRenderer>();
        ActiveTile.material.color = Color.yellow;


        if (a == 1 && LastHitObject != OurHitObject)
        {
            MeshRenderer LastTile = LastHitObject.GetComponentInChildren<MeshRenderer>();
            LastTile.material.color = Color.white;
        }
        LastHitObject = OurHitObject;
        a = 1;


    }

}