using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour {


    public Renderer rend;
    public PanelA panel;
    public GameObject alfa;
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        alfa = GameObject.Find("Background").transform.Find("panellos").gameObject;
        panel = alfa.GetComponentInChildren<PanelA>();
            }
    void OnMouseEnter()
    {
        rend.material.color = Color.red;
    }
    // Update is called once per frame
    void Update () {
    }
    void OnMouseOver()
    {
        rend.material.color -= new Color(0.1F, 0, 0) * 10*Time.deltaTime;
       
    }
    void OnMouseExit()
    {
        rend.material.color = Color.white;
    }

    private void OnMouseDown()
    {
    

        panel.Makenew();
    }

}
