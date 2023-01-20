using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FogManager : MonoBehaviour
{
    public Transform xRRig;
    [SerializeField]
    private float rigDepth;
    [SerializeField]
    private float fogFactor;
    [SerializeField]
    private float maxFogDepth;
    [SerializeField]
    private float rigDepthCorrected;
    public float maxFogDensity;
    public float minFogDensity;

    private void start()
    {
        maxFogDepth = 4.0f;
        maxFogDensity = 0.1f;
        minFogDensity = 0f;

    }

    void Update()
    {
        rigDepth = xRRig.position.y;

        if(rigDepth >= 2)
        {
            RenderSettings.fog = false;
        }
        else
        {
            RenderSettings.fog = true;
            RenderSettings.fogMode = FogMode.ExponentialSquared;
            
            if (rigDepth > 0)
            {
                rigDepthCorrected = rigDepth - 2;
                fogFactor = -rigDepthCorrected / maxFogDepth;
                RenderSettings.fogDensity = minFogDensity + fogFactor * (maxFogDensity - minFogDensity);
            }

            else
            {
                RenderSettings.fogDensity = maxFogDensity;
            }
        }
        

    }
}
