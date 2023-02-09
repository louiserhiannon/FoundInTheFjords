using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorOrcaMotionController : MonoBehaviour
{
    public LocomotionController_Orientation locomotionController;
    public Transform xRRig;
    private Vector3 orcaLocation;
    private float orcaLocationX;
    private float orcaLocationY;
    private float orcaLocationZ;
    private float yAdjust;

    // Update is called once per frame
    void Update()
    {
        MoveOrca();
        RotateOrca();
    }

    public void MoveOrca()
    {
        orcaLocationX = xRRig.position.x;
        orcaLocationZ = xRRig.position.z;
        orcaLocationY = 6.4f - xRRig.position.y;
        orcaLocation = new Vector3(orcaLocationX, orcaLocationY, orcaLocationZ);
        transform.position = orcaLocation;

    }

    public void RotateOrca()
    {
          
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 180 + xRRig.localEulerAngles.z, -xRRig.localEulerAngles.z);
    }
}
