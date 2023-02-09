using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    protected Renderer waterSurface;
    public float flowSpeedX;
    public float flowSpeedY;
    protected float textureOffsetX;
    protected float textureOffsetY;
    protected Vector2 textureFlow;
   
    void Start()
    {
        waterSurface = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        FlowPattern();
    }

    public virtual void FlowPattern()
    {
        textureOffsetX = flowSpeedX * Time.time;
        textureOffsetY = flowSpeedY * Time.time;
        textureFlow = new Vector2(textureOffsetX, textureOffsetY);
        waterSurface.material.mainTextureOffset = textureFlow;
    }
}
