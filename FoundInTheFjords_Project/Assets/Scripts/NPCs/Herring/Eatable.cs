using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eatable : MonoBehaviour
{
    private Material herringMaterial;
    private Color hoverColor;
    private Color nonHoverColor;
    private float lifetime = 0;

    // Start is called before the first frame update
    void Start()
    {
        herringMaterial = GetComponentInChildren<SkinnedMeshRenderer>().material;
        hoverColor = Color.magenta;
        nonHoverColor = Color.white;

    }

    private void Update()
    {
        lifetime += Time.deltaTime;
        if(lifetime >= EatingController.EC.herringLifetime)
        {
            //if(EatingController.EC.eatableHerring = this)
            //{
            //    EatingController.EC.eatableHerring = null;
            //}
            Destroy(gameObject);
        }
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
