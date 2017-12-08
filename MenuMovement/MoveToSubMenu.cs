using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToSubMenu : MonoBehaviour {

    bool mouseDown = false;

    private void OnMouseDown()
    {
        if (movingObject.GetComponent<CameraEnable>().isMoving == false)
        {
            mouseDown = true;
            movingObject.GetComponent<CameraEnable>().isMoving = true;
        }
        }
    

    public GameObject target;
    public GameObject movingObject;
    public float smoothTime = 1f;
    private Vector3 velocity = Vector3.zero;
    void Update()
    {
        if (mouseDown == true )
        {
            Vector3 targetPosition = target.GetComponent<Transform>().position;         
            movingObject.GetComponent<Transform>().position = Vector3.SmoothDamp(movingObject.GetComponent<Transform>().position, targetPosition, ref velocity, smoothTime);
            float distance = Vector3.Distance(movingObject.GetComponent<Transform>().position, target.GetComponent<Transform>().position);
            if (distance <= 0.05f)
            {
                mouseDown = false;
                movingObject.GetComponent<CameraEnable>().isMoving = false;
            }
        }
    }
}
