using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    protected float speed;
    [SerializeField] protected bool turning = false;
    //[SerializeField] protected bool turningAway = false;
    
    protected virtual void Start()
    {
        speed = Random.Range(FlockManager.FM.minSpeed, FlockManager.FM.maxSpeed);
    }

    
    protected void Update()
    {
        Bounds outerBounds = new(transform.position, FlockManager.FM.outerLimits);
        if (!outerBounds.Contains(transform.position))
        {
            turning= true;
            //turningAway = false;
        }
        //if (FlockManager.FM.innerBounds.Contains(transform.position))
        //{
        //    turning = false;
        //    turningAway = true;
        //}
        else
        {
            turning = false;
            //turningAway = false;
        }

        if (turning)
        {
            Vector3 direction = FlockManager.FM.transform.position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), FlockManager.FM.rotationSpeed * Time.deltaTime);
        }
        //else if (turningAway)
        //{
        //    Vector3 direction = transform.position - FlockManager.FM.transform.position;
        //    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), FlockManager.FM.rotationSpeed * Time.deltaTime);
        //}
        else
        {
            if (Random.Range(1, FlockManager.FM.flockSensitivity) < 10)
            {
                speed = Random.Range(FlockManager.FM.minSpeed, FlockManager.FM.maxSpeed);
            }

            if (Random.Range(1, FlockManager.FM.flockSensitivity) < 10)
            {
                ApplyRules();
            }
        }

        this.transform.Translate(0, 0, speed * Time.deltaTime);

    }

    protected void ApplyRules()
    {
        GameObject[] gos;
        gos = FlockManager.FM.allFlockers;

        //initialize local variables
        Vector3 vCentre = Vector3.zero;
        Vector3 vAvoid = Vector3.zero;
        float groupSpeed = 0.01f;
        float nDistance;
        int groupSize = 0;

        foreach(GameObject go in gos)
        {
            if(go != this.gameObject)
            {
                nDistance = Vector3.Distance(go.transform.position, this.transform.position);
                if(nDistance <= FlockManager.FM.neighbourDistance)
                {
                    vCentre += go.transform.position;
                    groupSize++;

                    if(nDistance < FlockManager.FM.avoidDistance)
                    {
                        vAvoid += (this.transform.position - go.transform.position);
                    }

                    Flock anotherFlock = go.GetComponent< Flock>();
                    groupSpeed += anotherFlock.speed;
                }
            }
        }

        if(groupSize > 0)
        {
            
            vCentre /= groupSize;
            vCentre += (FlockManager.FM.goalPosition - this.transform.position);
            speed = groupSpeed / groupSize;
            if(speed > FlockManager.FM.maxSpeed)
            {
                speed= FlockManager.FM.maxSpeed;
            }
            Vector3 direction = (vCentre + vAvoid) - transform.position;
            if(direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(direction), FlockManager.FM.rotationSpeed * Time.deltaTime);
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("orca"))
        {
            turning = true;
        }
        //if (other.CompareTag("shoal"))
        //{
        //    turningAway= true;  
        //}    

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("orca"))
        {
            turning = false;
        }
        //if (other.CompareTag("shoal"))
        //{
        //    turningAway = false;
        //}
        
    }
}
