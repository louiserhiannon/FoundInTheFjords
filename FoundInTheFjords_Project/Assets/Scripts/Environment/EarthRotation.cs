using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthRotation : MonoBehaviour
    //Controls rotation of the Earth
    
{
    public float rotateSpeed;
    public float rotationTime;

    void Update()
    {
        Debug.Log(Time.time);
        if (Time.time <= rotationTime)
        {
            transform.Rotate(-Vector3.up, rotateSpeed * Time.deltaTime);
        }
        
    }
}
