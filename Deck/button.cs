using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour {

    // Use this for initialization
    void Start() {
        var clones = GameObject.FindGameObjectsWithTag("clone");
        foreach (var clone in clones)
        {
            Destroy(clone);
        }
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnMouseDown()
    {
        var clones = GameObject.FindGameObjectsWithTag("clone");
        foreach (var clone in clones)
        {
            Destroy(clone);
        }
    } }
