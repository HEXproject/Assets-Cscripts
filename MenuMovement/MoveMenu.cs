using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMenu : MonoBehaviour {

    public GameObject band;
    public GameObject stick;
    public float deltaScale;
    public float deltax;
    public float velocity;

    bool mouseOverHex = false;
    private void OnMouseOver()
    {
        mouseOverHex = true;
    }
    private void OnMouseExit()
    {
        mouseOverHex = false;
    }

    // Use this for initialization
    void Start () {
        band.GetComponent<Transform>().localScale = new Vector3(0.001f, band.GetComponent<Transform>().localScale.y, band.GetComponent<Transform>().localScale.z);
        band.GetComponent<Transform>().GetChild(0).gameObject.SetActive(false);
        band.SetActive(false);
        stick.GetComponent<Transform>().position = new Vector3(stick.GetComponent<Transform>().position.x, stick.GetComponent<Transform>().position.y-10, stick.GetComponent<Transform>().position.z);
        deltaScale = 1.2f;
        velocity = 0.25f;
    }
	
	// Update is called once per frame
	void Update () {
        if (mouseOverHex)
        {
            moveDescriptionForward();
        }
        else
        {
            moveDescriptionBackward();
        }
	}

    void moveDescriptionForward()
    {
        if (stick.GetComponent<Transform>().position.y < 1)
        {
            stick.GetComponent<Transform>().position = new Vector3(stick.GetComponent<Transform>().position.x, stick.GetComponent<Transform>().position.y + velocity,
                stick.GetComponent<Transform>().position.z);
            return;
        }
        if (band.GetComponent<Transform>().localScale.x < 20 )
        {
            band.SetActive(true);
            band.GetComponent<Transform>().position = new Vector3(band.GetComponent<Transform>().position.x + deltax,
                band.GetComponent<Transform>().position.y, band.GetComponent<Transform>().position.z);
            band.GetComponent<Transform>().localScale = new Vector3(band.GetComponent<Transform>().localScale.x + deltaScale,
                band.GetComponent<Transform>().localScale.y, band.GetComponent<Transform>().localScale.z);
            return;
        }
        band.GetComponent<Transform>().GetChild(0).gameObject.SetActive(true);
        
    }

    void moveDescriptionBackward()
    {
        band.GetComponent<Transform>().GetChild(0).gameObject.SetActive(false);
        if (band.GetComponent<Transform>().localScale.x > 0.001f )
        {
            band.GetComponent<Transform>().position = new Vector3(band.GetComponent<Transform>().position.x - deltax,
                band.GetComponent<Transform>().position.y, band.GetComponent<Transform>().position.z);
            band.GetComponent<Transform>().localScale = new Vector3(band.GetComponent<Transform>().localScale.x - deltaScale,
                band.GetComponent<Transform>().localScale.y, band.GetComponent<Transform>().localScale.z);
            return;
        }
        if (stick.GetComponent<Transform>().position.y > -10)
        {
            band.SetActive(false);
            stick.GetComponent<Transform>().position = new Vector3(stick.GetComponent<Transform>().position.x, stick.GetComponent<Transform>().position.y - velocity,
                stick.GetComponent<Transform>().position.z);
            return;
        }
        
        
    }
}
