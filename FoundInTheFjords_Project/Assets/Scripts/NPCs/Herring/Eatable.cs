using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eatable : MonoBehaviour
{
    private Material herringMaterial;
    private Color hoverColor;
    private Color nonHoverColor;

    // Start is called before the first frame update
    void Start()
    {
        herringMaterial = GetComponentInChildren<SkinnedMeshRenderer>().material;
        hoverColor = Color.magenta;
        nonHoverColor = Color.white;

    }

    public void OnHoverStart()
    {
        herringMaterial.color = hoverColor;
    }

    public void OnHoverEnd()
    {
        herringMaterial.color = nonHoverColor;
    }


}
