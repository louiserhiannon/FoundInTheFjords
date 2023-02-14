using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogManager_Orientation : FogManager
{
    public GameObject mirrorOrca;
    public GameObject mirrorJelly;
    public GameObject upperSeaBox;
    public GameObject terrain;
    public MeshRenderer waterSurfaceRenderer;
    private Material surfaceMaterial;
    private Color surfaceColour;

    private void Awake()
    {
        surfaceMaterial = waterSurfaceRenderer.material;
    }

    public override void Update()
    {
        base.Update();
        if (headsetDepthCorrected >= 0)
        {
            mirrorOrca.SetActive(false);
            mirrorJelly.SetActive(false);
            upperSeaBox.SetActive(false);
            terrain.SetActive(true);
            SetSurfaceAlpha();
        }
        else
        {
            mirrorOrca.SetActive(true);
            mirrorJelly.SetActive(true);
            upperSeaBox.SetActive(true);
            terrain.SetActive(false);
            ResetSurfaceAlpha();
        }
    }

    private void SetSurfaceAlpha()
    {
        surfaceColour = surfaceMaterial.color;
        surfaceColour.a = 1.0f;
        surfaceMaterial.color = surfaceColour;
    }

    private void ResetSurfaceAlpha()
    {
        surfaceColour = surfaceMaterial.color;
        surfaceColour.a = 0.12f;
        surfaceMaterial.color = surfaceColour;
    }
}
