using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarouselManager : MonoBehaviour
{
    public static CarouselManager CM;
    public GameObject axisPrefab;
    public int numOrca;
    public GameObject[] allAxes;
    public Transform carouselTransform;
    //public GameObject orcaPrefab;
    //public GameObject[] orcas;

    [Header("Orca Settings")]
    [Range(0.0f, 5.0f)]
    public float minOffset;
    [Range(0.0f, 5.0f)]
    public float maxOffset;
    [Range(-0.03f, 0.0f)]
    public float minTimeShift;
    [Range(0.0f, 0.03f)]
    public float maxTimeShift;
    [Range(1f, 5f)]
    public float minTimeStretch;
    [Range(1f, 5f)]
    public float maxTimeStretch;
    [Range(15f, 25.0f)]
    public float minSpeed;
    [Range(15f, 25.0f)]
    public float maxSpeed;
    [Range(-1.0f, 0.0f)]
    public float minAcceleration;
    [Range(0.0f, 1.0f)]
    public float maxAcceleration;
    [Range(10, 1000)]
    public int pathSensitivity;
    [Range(0.005f, 0.05f)]
    public float pathWanderSpeed;
    [Range(100, 1000)]
    public int distanceSensitivity;
    [Range(100, 5000)]
    public int animationSensitivity;
    public bool controlSpeedWithDistance;


    // Start is called before the first frame update
    void Awake()
    {
        //instantiate "numOrca" of axes at random orientations
        allAxes = new GameObject[numOrca];
        for(int i = 0; i < numOrca; i++)
        {
            Quaternion axisRotation = Random.rotation;
            allAxes[i] = Instantiate(axisPrefab, transform.position, axisRotation, carouselTransform);

        }
        CM = this;
    }

    
}
