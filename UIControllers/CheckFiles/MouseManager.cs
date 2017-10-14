using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour
{
    public GameObject LastHitObject;
    public GameObject LastClickedObject;
    public GameObject ChosenHexFromHand;
    int a = 0;
    public int range;
    public int ksztalt;
    
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
        //Debug.Log("Raycast hit " + OurHitObject.name);

        MeshRenderer ActiveTile = OurHitObject.GetComponentInChildren<MeshRenderer>();
        ActiveTile.material.color = Color.yellow;

        if (Input.GetMouseButtonDown(0) && ChosenHexFromHand != null)
        {
            ChosenHexFromHand.GetComponent<Transform>().Rotate(Vector3.right * 90);
            Vector3 newPosition = new Vector3(LastHitObject.transform.position.x, LastHitObject.transform.position.y + 1, LastHitObject.transform.position.z);
            ChosenHexFromHand.GetComponent<Transform>().position = newPosition;
            
        }
        if(Input.GetMouseButtonDown(0))
        {
            if (ksztalt == 0 )
            {
                if (OurHitObject != LastClickedObject && LastClickedObject != null)
                {
                    color_line(OurHitObject);
                }
                LastClickedObject = OurHitObject;
            }
            else
                color_circle(OurHitObject);

        }


            if (a == 1 && LastHitObject != OurHitObject && ActiveTile.material.color == Color.yellow)
        {
            MeshRenderer LastTile = LastHitObject.GetComponentInChildren<MeshRenderer>();
            LastTile.material.color = Color.white;
        }
        LastHitObject = OurHitObject;
        a = 1;


    }
    void color_circle(GameObject OurHitObject)
    {
        int x = OurHitObject.GetComponent<Hex>().x;
        int y = OurHitObject.GetComponent<Hex>().y;

        int a = -range + range / 2;
        int b = range - ((range + 1) / 2);

        if (y % 2 == 0)
        {

            for (int i = -range; i <= range; i++)
            {
                for (int j = a; j <= b; j++)
                {

                    if (GameObject.Find("HEX_" + (x + j) + "_" + (y + i)) != null)
                    {
                        Hex active = GameObject.Find("HEX_" + (x + j) + "_" + (y + i)).GetComponent<Hex>();
                        MeshRenderer mr = active.GetComponentInChildren<MeshRenderer>();
                        mr.material.color = Color.red;
                    }



                }

                if (i < 0)
                {
                    if (i % 2 == -1)
                    {
                        b++;
                    }
                    else
                    {
                        a--;
                    }
                }
                else
                {
                    if (i % 2 == 1)
                    {
                        a++;
                    }
                    else
                    {
                        b--;
                    }
                }
            }
        }
        else
        {
            if(range%2==0)
            {
                a--;
                b--;
            }
            for (int i = -range; i <= range; i++)
            {
                for (int j = a+1; j <= b + 1; j++)
                {
                    if (GameObject.Find("HEX_" + (x + j) + "_" + (y + i)) != null)
                    {
                        Hex active = GameObject.Find("HEX_" + (x + j) + "_" + (y + i)).GetComponent<Hex>();
                        MeshRenderer mr = active.GetComponentInChildren<MeshRenderer>();
                        mr.material.color = Color.red;
                    }
                }

                if (i < 0)
                {
                    if (i % 2 == 0)
                    {
                        b++;
                    }
                    else
                    {
                        a--;
                    }
                }
                else
                {
                    if (i % 2 == 0)
                    {
                        a++;
                    }
                    else
                    {
                        b--;
                    }
                }
            }
        }
    }


    void color_line(GameObject OurHitObject)
    {

        int ax = OurHitObject.GetComponent<Hex>().x;
        int ay = OurHitObject.GetComponent<Hex>().y;

        int bx = LastClickedObject.GetComponent<Hex>().x;
        int by = LastClickedObject.GetComponent<Hex>().y;
       
        draw_line(OurHitObject,LastClickedObject);
       
    }

    float lerp(float a,float b,float t)
    {
        //Debug.Log((float)(a + (b - a) * t));
        return  Mathf.Round(a+0.0001f + (b - a) * t);
        
       
    }


    void draw_line(GameObject OurHitObject, GameObject LastClickObject)
    {
        int qa = OurHitObject.GetComponent<Hex>().x;
        int ra = OurHitObject.GetComponent<Hex>().y;
        int ax = (int)(qa - (ra - (ra & 1)) / 2);
        int az = ra;
        int ay = -ax - az;
        

        int qb = LastClickedObject.GetComponent<Hex>().x;
        int rb = LastClickedObject.GetComponent<Hex>().y;
        int bx = (int)(qb - (rb - (rb & 1)) / 2);
        int bz = rb;
        int by = -bx - bz;
        
        float n = Mathf.Max(Mathf.Abs(ax - bx), Mathf.Abs(ay - by), Mathf.Abs(az - bz));
        Debug.Log("n="+n);
        float t = 1.0f / n;
        
        for (int i = 0; i <= n; i++)
        {
            float x = lerp(ax, bx, t*i);
            float z = lerp(az, bz, t*i);
            Debug.Log("x+z=" + x + " " + z);
            float q =(x + (z - (z %2)) / 2);
            float r = z;
            Debug.Log("q+r="+q + " " + r);
            if(GameObject.Find("HEX_" + q + "_" + r)!=null)
            {
                Hex active = GameObject.Find("HEX_" + q + "_" + r).GetComponent<Hex>();
                MeshRenderer mr = active.GetComponentInChildren<MeshRenderer>();
                mr.material.color = Color.red;
            }
            
        }


    }
    
    

    
}