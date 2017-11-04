using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoomer : MonoBehaviour {

    public float speed;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate() {
        if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
            GetComponent<Camera>().transform.Translate(0, speed, -speed*2);
        if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
            GetComponent<Camera>().transform.Translate(0, -speed, speed*2);
    }
}
