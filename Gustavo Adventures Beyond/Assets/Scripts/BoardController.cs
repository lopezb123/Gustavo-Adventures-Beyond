using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private Rigidbody boardRb;
    private float jumpForce = 6;
    private float horInput;
    private float vertInput;
    private float turnAngle;
    private bool footBrake;
    private float currentBrake;
    private bool isGrounded = true;
    private Vector3 centMass;

    [SerializeField] private Rigidbody boardBody;

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
    void Start(){
        boardRb = boardBody;
        boardRb.centerOfMass = centMass;
    }
    private void Update()
    {
        GetInput();
        ApplyJump();
        HandleSpeed();
        HandleSteering();
    }

    private void GetInput()
    {
        horInput = Input.GetAxis(HORIZONTAL);
        vertInput = Input.GetAxis(VERTICAL);
    }

    private void ApplyJump()
    {
         if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            boardRb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            isGrounded = false;
         }
    }
    private void HandleSpeed()
    {
        FLCollider.motorTorque = vertInput * speedForce;
        FRCollider.motorTorque = vertInput * speedForce;
        
    }

    private void HandleSteering()
    {
        turnAngle = maxAngle * horInput;
        FLCollider.steerAngle = turnAngle;
        FRCollider.steerAngle = turnAngle;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Ground"){
            isGrounded = true;
        }

        //We need these two functions in this one,
        //else the player will get stuck on a wall when they collide with it
        //HandleSpeed();
        //HandleSteering();
    }
}
