using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float turnSpeed;

    private void FixedUpdate()
    {
        move();
        turn();
    }

    private void move()
    {
        var targetPosition = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    private void turn()
    {
        var directrion = target.position - transform.position;
        var rotation = Quaternion.LookRotation(directrion, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
    }
}
