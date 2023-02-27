using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanMovement : MonoBehaviour
    //Controls the movement of the Ocean Boxes to give the sensation of fast movement. Blocks of underwater environment move rapidly in an "infinite runner" mechanic.
{
    public List<Transform> activePoints;
    public List<GameObject> oceanBoxPrefabs;
    public float currentDistance;
    public float speed;
    public float maxSpeed;
    public float maxDistance;
    public float endPositionZ;
    public float acceleration;
    // Start is called before the first frame update
    void Start()
    {
        //instantiate ocean boxes
        for (int i = 0; i < activePoints.Count; i++)
        {
            Instantiate(oceanBoxPrefabs[i], activePoints[i], false);
        }

        //set current distance to 0
        currentDistance = 0f;
        //set max speed
        maxSpeed = 15f; //15 m/s is the equivalent of 54 km/hr
        maxDistance = 10000f;
        endPositionZ = -1100f;
        speed= 0f;
        acceleration = 0.05f;


    }
        
    void Update()
    {
        if (currentDistance < maxDistance)
        {
            
            for (int i = 0; i < activePoints.Count; i++)
            {
                //if box is beyond the end of the range, flip it back to the beginning
                if (activePoints[i].transform.position.z <= endPositionZ)
                {
                    activePoints[i].transform.Translate(0f, 0f, 1500f);
                }
                //otherwise move it along at a specific speed
                activePoints[i].transform.Translate(0f, 0f, -speed * Time.deltaTime);

                
            }
            currentDistance += speed * Time.deltaTime; //update distance travelled
            if (speed < maxSpeed)
            {
                speed += acceleration; //control speed
            }
        } 
        
    }
}
