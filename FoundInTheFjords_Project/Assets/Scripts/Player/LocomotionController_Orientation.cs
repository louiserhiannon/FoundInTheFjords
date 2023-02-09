using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionController_Orientation : LocomotionController
{
    [SerializeField] private Vector3 newLocalEulerAngle;
    public override void MoveForwardRelativeToCamera(float relativeForwardSpeed)
    {
        moveSpeed = relativeForwardSpeed * maxSpeed;
        if (moveSpeed == 0f)
        {
            timeAtZero += Time.deltaTime;
            if (timeAtZero > 2f)
            {
                currentSpeed = 0f;
                timeAtZero = 0f;
            }
        }

        if (currentSpeed < moveSpeed)
        {
            currentSpeed += acceleration;
        }

        if (currentSpeed > moveSpeed)
        {
            currentSpeed -= acceleration;
        }

        xrRig.transform.Translate(Vector3.up * currentSpeed * Time.deltaTime, Space.World);
    }

    

    public override void MoveSidewaysRelativeToCamera(float relativeSidewaysSpeed)
    {
        //translate sideways
        sidewaysSpeed = relativeSidewaysSpeed * maxTranslateSpeed;
        Vector3 sidewaysVector = new Vector3(sidewaysSpeed, 0, 0); 
        xrRig.transform.Translate(sidewaysVector * Time.deltaTime, Space.World);

        //Rotate along local z axis
        spinAngleMax = 35f;
        //Add smoothing effect

        desiredAngle = -relativeSidewaysSpeed * spinAngleMax; //desired angle is between -25 (right) and +25 (left)
        rotationToDesiredAngle = (desiredAngle - currentAngle) / smoothingFactor;
        updatedAngle = currentAngle + rotationToDesiredAngle;
        newLocalEulerAngle = new Vector3(xrRig.transform.localEulerAngles.x, xrRig.transform.localEulerAngles.y, updatedAngle);
        xrRig.transform.localEulerAngles = newLocalEulerAngle;

        currentAngle = updatedAngle;

    }

    public override void JumpUp(InputAction.CallbackContext context)
    {
        xrRig.Translate(0f, 0f, 0f);
    }

    public override void JumpDown(InputAction.CallbackContext context)
    {
        xrRig.Translate(0f, 0f, 0f);
    }
}
