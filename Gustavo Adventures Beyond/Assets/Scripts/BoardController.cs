using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horInput;
    private float vertInput;
    private float turnAngle;
    private bool footBrake;
    private float currentBrake;

    [SerializeField] private float speedForce;
    [SerializeField] private float brakeForce;
    [SerializeField] private float maxAngle;

    [SerializeField] private WheelCollider FLCollider;
    [SerializeField] private WheelCollider FRCollider;
    [SerializeField] private WheelCollider BLCollider;
    [SerializeField] private WheelCollider BRCollider;

    [SerializeField] private Transform FLTransform;
    [SerializeField] private Transform FRTransform;
    [SerializeField] private Transform BLTransform;
    [SerializeField] private Transform BRTransform;

    private void FixedUpdate()
    {
        GetInput();
        HandleSpeed();
        HandleSteering();
        UpdateBoard();
    }

    private void GetInput()
    {
        horInput = Input.GetAxis(HORIZONTAL);
        vertInput = Input.GetAxis(VERTICAL);
        footBrake = Input.GetKey(KeyCode.Space);
    }

    private void HandleSpeed()
    {
        FLCollider.motorTorque = vertInput * speedForce;
        FRCollider.motorTorque = vertInput * speedForce;
        currentBrake = footBrake ? brakeForce : 0f;
        if(footBrake){
            ApplyBrakes();
        }
    }

    private void ApplyBrakes()
    {
        FLCollider.brakeTorque = currentBrake;
        FRCollider.brakeTorque = currentBrake;
        BLCollider.brakeTorque = currentBrake;
        BRCollider.brakeTorque = currentBrake;
    }

    private void HandleSteering()
    {
        turnAngle = maxAngle * horInput;
        FLCollider.steerAngle = turnAngle;
        FRCollider.steerAngle = turnAngle;
    }

    private void UpdateBoard()
    {
        UpdateWheel(FLCollider, FLTransform);
        UpdateWheel(FRCollider, FRTransform);
        UpdateWheel(BLCollider, BLTransform);
        UpdateWheel(BRCollider, BRTransform);
    }

    private void UpdateWheel(WheelCollider wCollider, Transform wTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wCollider.GetWorldPose( out pos, out rot);
        wTransform.rotation = rot;
        wTransform.position = pos;
    }
}
