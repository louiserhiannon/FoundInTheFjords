using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;

public class LocomotionController : MonoBehaviour
{
    public InputActionReference moveSpeedReference = null;
    private Transform xrRig;
    private Camera mainCamera;
    [SerializeField] private Vector3 cameraForward = new Vector3();
    private Vector3 netCameraVector = new Vector3();
    private float moveSpeed;
    public float maxSpeed = 2f;
    public float spinAngleMax;
    // Start is called before the first frame update
    private void Awake()
    {
        xrRig = GetComponent<Transform>(); 
        mainCamera = GetComponentInChildren<Camera>();
        
    }
    
    private void Update()
    {
        Vector2 thumbstickPosition = moveSpeedReference.action.ReadValue<Vector2>();
        float yvalue = thumbstickPosition.y;
        float xvalue = thumbstickPosition.x;
        MoveRelativeToCamera(yvalue);
        if (xvalue < -0.1 || xvalue > 0.1)
        {
            SpinOnAxis(xvalue);
        }
        SpinOnAxis(xvalue);
    }

    public void MoveRelativeToCamera(float relativeMoveSpeed)
    {
        moveSpeed = relativeMoveSpeed * maxSpeed;
        cameraForward = mainCamera.transform.forward;
        netCameraVector = moveSpeed * cameraForward;

        xrRig.transform.Translate(netCameraVector * Time.deltaTime, Space.World);
    }

    public void SpinOnAxis(float relativeSpinSpeed)
    {
            spinAngleMax = 45f;
            xrRig.transform.localEulerAngles = new Vector3(xrRig.transform.localEulerAngles.x, xrRig.transform.localEulerAngles.y, -relativeSpinSpeed * spinAngleMax);
        
    }
}
