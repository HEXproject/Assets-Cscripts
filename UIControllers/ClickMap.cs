﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame

     void Update()
     {
         if (Input.GetMouseButtonDown(0))
         {
             RaycastHit hitInfo = new RaycastHit();
             if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
             {
                 print ("It's working");
             }
         }
     }
 }

