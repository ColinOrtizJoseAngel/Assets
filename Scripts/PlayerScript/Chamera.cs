using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chamera : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;

    public Vector3 offset;

    public bool follow = true;

    //transition
    public Transform endMarker = null; //Posicion a la que se movera


    void FixedUpdate()
    {
        if (follow == true)
        {
            follow_camera();
        }
        else
        {
            move_camera();
        }
        

    }

    void follow_camera()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

    }
    void move_camera()
    {
        transform.position = Vector3.Lerp(transform.position, endMarker.position, Time.deltaTime);
    }
}