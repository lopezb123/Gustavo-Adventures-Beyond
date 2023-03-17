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
        //jump if it is either making contact with an object aka collision is entered or if the board yaxis is on the ground, which is y<0
         if(Input.GetKeyDown(KeyCode.Space) && (isGrounded || (transform.position.y < 0))){
            boardRb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
         }
    }
    private void HandleSpeed()
    {
        FLCollider.motorTorque = vertInput * speedForce;
        FRCollider.motorTorque = vertInput * speedForce;
        BLCollider.motorTorque = vertInput * speedForce;
        BRCollider.motorTorque = vertInput * speedForce;
    }

    private void HandleSteering()
    {
        turnAngle = maxAngle * horInput;
        FLCollider.steerAngle = turnAngle;
        FRCollider.steerAngle = turnAngle;
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
    public bool getIsGrounded(){
        return isGrounded;
    }
}
