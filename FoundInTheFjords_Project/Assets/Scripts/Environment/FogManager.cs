using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FogManager : MonoBehaviour
    //Controls the density and appearance of fog in renderer so it is deactivated above water and increases with depth underwater
{
    public Transform xRRig; //Transform component of XR Rig Game object
    [SerializeField]
    private float rigDepth; //y-coordinate (height) of rig in world space
    [SerializeField]
    private float fogFactor; // normalized value (between 0 and 1) used to calculate fog density at a given depth
    [SerializeField]
    private float maxFogDepth; // depth (negative height) at which fog density reaches maximum value
    [SerializeField]
    private float rigDepthCorrected; // corrected depth that takes into account that ocean surface is at y = 2 (due to sky box)
    public float maxFogDensity; // max fog density value (occurs at max fog depth and beyond
    public float minFogDensity; // minimum fog density value (occurs at water surface

    void Start()
    {
        maxFogDepth = -20.0f;
        maxFogDensity = 0.1f;
        minFogDensity = 0.03f;

    }

    void Update()
    {
        rigDepth = xRRig.position.y;
        rigDepthCorrected = rigDepth - 2;

        //when the camera is above the water surface
        if (rigDepthCorrected >= 0)
        {
            //Switch off fog
            RenderSettings.fog = false;
            //turn down light
            RenderSettings.ambientIntensity = 2f;
        }
        else
        {
            //switch on fog using exponential squared setting
            RenderSettings.fog = true;
            RenderSettings.fogMode = FogMode.ExponentialSquared;
            RenderSettings.ambientIntensity = 3f;
            

            //when the rig is shallower than the max fog depth (note that depth is a negative value so shallower depths correspond to larger [less negative] numbers)
            if (rigDepth > maxFogDepth)
            {
                
                //the fog density is a linear interpolation from min to max based on depth
                fogFactor = rigDepthCorrected / maxFogDepth;
                RenderSettings.fogDensity = minFogDensity + fogFactor * (maxFogDensity - minFogDensity);
            }

            else
            {
                //Once below the max depth, fog is set to the max density.
                RenderSettings.fogDensity = maxFogDensity;
            }
        }
        

    }
}
