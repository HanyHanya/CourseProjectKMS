using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField]
    Transform targetPos;

    int min = 6;
    int max = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Rotating camera around invisible point with middle mouse button
        if(Input.GetMouseButton(2))
        {
            transform.RotateAround(targetPos.position, Vector3.up, Input.GetAxis("Mouse X") * 2);
            transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y") * 2);
        }

        //Zooming camera
        if(Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Vector3 newpos = transform.position + 
            transform.TransformDirection(Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * 4);

            if (ControlDistance(Vector3.Distance(newpos, targetPos.position)))
                transform.position = newpos;
        }

        //Movement
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if(x != 0 || y != 0)
        {
            Vector3 newpos = transform.position + 
            transform.TransformDirection(new Vector3(x/5, 0, 0) + Vector3.up * y/5);

            if(ControlDistance(Vector3.Distance(newpos, targetPos.position)))
                transform.position = newpos;
        }
    }

    //Check for the nearby object
    bool ControlDistance (float distance)
    {

        if (distance > min && distance < max)
            return true;
        else
            return false;
    }
}
