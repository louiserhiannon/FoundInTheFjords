using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public static FlockManager FM;
    public GameObject herringPrefab;
    public int numHerring;
    public GameObject[] allHerring;
    public Vector3 swimLimits = new Vector3(1f, 1f, 1f);
    public Vector3 goalPosition = Vector3.zero;

    [Header("Fish Settings")]
    [Range(0.1f, 5.0f)]
    public float minSpeed;
    [Range(0.1f, 5.0f)]
    public float maxSpeed;
    [Range(1.0f, 10.0f)]
    public float neighbourDistance;
    [Range(0.1f, 2.0f)]
    public float avoidDistance;
    [Range(1.0f, 5.0f)]
    public float rotationSpeed;


    // Start is called before the first frame update
    void Start()
    {
        allHerring = new GameObject[numHerring];
        for (int i = 0; i < numHerring; i++)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-swimLimits.x, swimLimits.x), Random.Range(-swimLimits.y, swimLimits.y), Random.Range(-swimLimits.z, swimLimits.z));
            allHerring[i] = Instantiate(herringPrefab, pos, Quaternion.identity); 

        }
        FM = this;
        goalPosition = this.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if(Random.Range(1, 100) < 10)
        {
            goalPosition = this.transform.position + new Vector3(Random.Range(-swimLimits.x, swimLimits.x), Random.Range(-swimLimits.y, swimLimits.y), Random.Range(-swimLimits.z, swimLimits.z));
        }
    }
}
