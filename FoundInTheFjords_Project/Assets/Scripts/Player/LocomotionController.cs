using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;

public class LocomotionController : MonoBehaviour
{
    public InputActionReference moveSpeedReference = null;
    public InputActionReference upJumpReference = null;
    public InputActionReference downJumpReference = null;
    private Transform xrRig;
    private Camera mainCamera;
    [SerializeField] private Vector3 cameraForward = new Vector3();
    [SerializeField] private Vector3 cameraRight = new Vector3();
    private Vector3 netCameraVector = new Vector3();
    private Vector3 sidewaysCameraVector = new Vector3();
    [SerializeField] private float moveSpeed;
    private float sidewaysSpeed;
    public float maxSpeed = 2f;
    public float maxTranslateSpeed = 0.5f;
    public float spinAngleMax;
    [SerializeField] private float currentSpeed;
    private float acceleration;
    private float desiredAngle;
    private float rotationToDesiredAngle;
    private float updatedAngle;
    private float currentAngle;
    private float smoothingFactor = 10f;
    private float jumpAmount = 0.5f;
    [SerializeField]private float timeAtZero = 0f;
    
    // Start is called before the first frame update
    private void Awake()
    {
        xrRig = GetComponent<Transform>(); 
        mainCamera = GetComponentInChildren<Camera>();
        currentSpeed = 0f;
        acceleration = 0.05f;
        currentAngle= 0f;
      
        
    }

    private void OnEnable()
    {
        upJumpReference.action.started += JumpUp;
        downJumpReference.action.started += JumpDown;
    }

    private void OnDisable()
    {
        upJumpReference.action.started -= JumpUp;
        downJumpReference.action.started -= JumpDown;
    }

    private void Update()
    {
        Vector2 thumbstickPosition = moveSpeedReference.action.ReadValue<Vector2>();
        float yvalue = thumbstickPosition.y;
        float xvalue = thumbstickPosition.x;        
        MoveForwardRelativeToCamera(yvalue);
        MoveSidewaysRelativeToCamera(xvalue);
        
    }

    public void MoveForwardRelativeToCamera(float relativeForwardSpeed)
    {
        moveSpeed = relativeForwardSpeed * maxSpeed;
        if (moveSpeed == 0f)
        {
            timeAtZero += Time.deltaTime;
            if (timeAtZero > 2f)
            {
                currentSpeed = 0f;
                timeAtZero= 0f;
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
        
        
              
        cameraForward = mainCamera.transform.forward;
        netCameraVector = currentSpeed * cameraForward;

        xrRig.transform.Translate(netCameraVector * Time.deltaTime, Space.World);
    }

    public void MoveSidewaysRelativeToCamera(float relativeSidewaysSpeed)
    {
        
        //Rotate along local z axis
        spinAngleMax = 35f;
            //Add smoothing effect
              
        desiredAngle = -relativeSidewaysSpeed * spinAngleMax; //desired angle is between -25 (right) and +25 (left)
        rotationToDesiredAngle = (desiredAngle - currentAngle) / smoothingFactor;
        updatedAngle = currentAngle + rotationToDesiredAngle;


        xrRig.transform.localEulerAngles = new Vector3(xrRig.transform.localEulerAngles.x, xrRig.transform.localEulerAngles.y, updatedAngle);

        currentAngle = updatedAngle;
        
        //translate sideways
        sidewaysSpeed = relativeSidewaysSpeed * maxTranslateSpeed;
        cameraRight = mainCamera.transform.right;
        cameraRight.y = 0f;
        cameraRight.Normalize();
        sidewaysCameraVector = sidewaysSpeed * cameraRight;
        
        xrRig.transform.Translate(sidewaysCameraVector * Time.deltaTime, Space.World);

    }

    public void JumpUp(InputAction.CallbackContext context)
    {
        xrRig.Translate(0f, jumpAmount, 0f);
    }

    public void JumpDown(InputAction.CallbackContext context)
    {
        xrRig.Translate(0f, -jumpAmount, 0f);
    }
}
