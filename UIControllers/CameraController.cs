using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float speed;
    float minRotation = 1;
    float maxRotation = 45;
    

    void Start()
    {
        
    }

    void FixedUpdate()
    {   
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        //left and right
        if (Mathf.Abs(moveHorizontal) > Mathf.Abs(moveVertical))
        {
            if (moveHorizontal > 0)
                transform.Rotate(Vector3.up, -speed * Time.deltaTime* 10);
            else
                transform.Rotate(Vector3.up, speed * Time.deltaTime);
        }

        //up and down
        
        if (Mathf.Abs(moveHorizontal) < Mathf.Abs(moveVertical))
        {
            if (moveVertical < 0)
            {
                transform.Rotate(Vector3.right, -speed );
            }
            else
            {
                transform.Rotate(Vector3.right, speed );
            }
        }
        
        Vector3 currentRotation = transform.rotation.eulerAngles;
        currentRotation.x = Mathf.Clamp(currentRotation.x, minRotation, maxRotation);
        transform.localRotation = Quaternion.Euler(currentRotation);

    }
}
