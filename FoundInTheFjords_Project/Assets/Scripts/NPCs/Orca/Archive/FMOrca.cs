using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMOrca : FlockManager
{
    
    public static FMOrca fMOrca;
    //public Bounds innerBounds; 
    //public Vector3 predatorZone = new Vector3(1f, 1f, 4f);

    public override void Start()
    {
        base.Start();

        for (int i = 0; i < numFlockers; i++)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-outerLimits.x, outerLimits.x), Random.Range(-outerLimits.y, outerLimits.y), Random.Range(-outerLimits.z, outerLimits.z));
            allFlockers[i] = Instantiate(flockerPrefab, pos, Quaternion.identity);
            
        }
    }

    public override void Update()
    {
        base.Update();
        if (Random.Range(1, 1000) < 10)
        {
            goalPosition = this.transform.position + new Vector3(0, Random.Range(-outerLimits.y, outerLimits.y), 0);
        }
        //calculate predator bounds
        //for (int i = 0; i < numFlockers; i++)
        //{
        //    predatorColliders[i] = allFlockers[i].GetComponent<BoxCollider>();
        //}
        
        //calculate inner bounds
        //innerBounds = new Bounds(transform.position, swimLimits * 0.75f);
    }
}
