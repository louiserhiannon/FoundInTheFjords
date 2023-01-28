using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private Renderer waterSurface;
    public float flowSpeedX;
    public float flowSpeedY;
    private float textureOffsetX;
    private float textureOffsetY;
   

    private Vector2 textureFlow;
    void Start()
    {
        waterSurface = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        textureOffsetX = flowSpeedX * Time.time;
        textureOffsetY = flowSpeedY * Time.time;
        textureFlow = new Vector2(textureOffsetX, textureOffsetY);
        waterSurface.material.mainTextureOffset = textureFlow;
    }
}
