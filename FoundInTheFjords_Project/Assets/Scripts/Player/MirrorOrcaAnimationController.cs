using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UIElements;
using System.Xml.Schema;

public class MirrorOrcaAnimationController : MonoBehaviour
{
    //Script to convert controller inputs into mirror animations on the orca reflection during orientation   
    public InputActionReference biteAction = null;
    public InputActionReference swimAction = null;
    public InputActionReference tailSlapAction = null;
    private Animator mirrorOrcaAnimator;
    private float slapCharge = 0f;
    private float tailChargeRequired = 300f;
    public bool tailCharged = false;
    public float tailChargeDisplayed;
    public TMP_Text tailChargeText;
    public TMP_Text chargedText;
    [SerializeField] private float yvalue;
    [SerializeField] private float xvalue;
    [SerializeField] private float gripValue;
    
    

    void Awake()
    {
        mirrorOrcaAnimator= GetComponent<Animator>();
        chargedText.text = "Ready";
        tailChargeText.text = "Ready";
        
    }

    private void OnEnable()
    {
        biteAction.action.started += Bite;
    }

    private void OnDisable()
    {
        biteAction.action.started -= Bite;
    }

      void Update()
    {
        Vector2 thumbstickPosition = swimAction.action.ReadValue<Vector2>();
        yvalue = thumbstickPosition.y;
        xvalue = thumbstickPosition.x;
        float gripPosition = tailSlapAction.action.ReadValue<float>();
        gripValue = gripPosition;
        Swim(yvalue, xvalue);
        TailSlap(gripValue);
        
        
    }

    public void Bite(InputAction.CallbackContext context)
    {
        if(mirrorOrcaAnimator!= null)
        {
            mirrorOrcaAnimator.SetTrigger("Trigger_Bite");
        }
    }

    public void TailSlap(float value)
    {
        slapCharge += value;
        tailChargeDisplayed = Mathf.Clamp(slapCharge, 0f, tailChargeRequired);
        tailChargeText.text = tailChargeDisplayed.ToString();
        if (slapCharge > tailChargeRequired) //there must be a better way of doing this that doesn't involve using the same if statement twice...
        {
            tailCharged = true;
            chargedText.text = "Charged";
        }

        if (value < 0.05f)
        {
            if (tailCharged == true)
            {
                if (mirrorOrcaAnimator != null)
                {
                    mirrorOrcaAnimator.SetTrigger("Trigger_TailSlap");
                }
            }
            slapCharge = 0f;
            tailCharged = false;
            chargedText.text = string.Empty;
            tailChargeText.text = string.Empty;

        }

        
    }

    public void Swim(float xValue, float yValue)
    {
              
        if (mirrorOrcaAnimator != null)
        {
            if (xValue > 0.5f || xValue < -0.5f || yValue > 0.5f || yValue < -0.5f)
            {
                mirrorOrcaAnimator.SetTrigger("Trigger_Swim");
                
                
            }
            else
            {
                mirrorOrcaAnimator.SetTrigger("Trigger_StopSwim");
            }
                
        }
    }

    

}
