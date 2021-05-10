using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovementHandler : MonoBehaviour
{
    Vector3 movementVector;
    Quaternion rotation;
    [SerializeField] private float impulseForce;
    [SerializeField] Rigidbody bodyToMove;
    [SerializeField] Transform bodyToRotate;
    bool moveImplemented;

    private void Awake()
    {
        movementVector = Vector3.zero;
        rotation = Quaternion.Euler(0, 0, 0);
        moveImplemented = true;
        impulseForce = GlobalFixedConstants.impulseForce;
    }

    private void OnEnable()
    {
        TestPlayerInputManager.moveDown += AddBackwardsForce;
        TestPlayerInputManager.moveUp += AddForwardForce;
        TestPlayerInputManager.moveRight += RotateRight;
        TestPlayerInputManager.moveLeft += RotateLeft;
        TestPlayerInputManager.StrafeLeftRequest += StrafeLeft;
        TestPlayerInputManager.StrafeRightRequest += StrafeRight;
        TestPlayerInputManager.jump += AddUpwardsForce;
        TestPlayerInputManager.onLeftImpact += RotateRight;
        TestPlayerInputManager.onRightImpact += RotateLeft;
    }

    private void StrafeRight(object sender, System.EventArgs e)
    {
        movementVector = new Vector3(impulseForce, 0, 0);
        moveImplemented = false;
    }

    private void StrafeLeft(object sender, System.EventArgs e)
    {
        movementVector = new Vector3(-1 * impulseForce, 0, 0);
        moveImplemented = false;
    }

    private void AddUpwardsForce(object sender, System.EventArgs e)
    {
        movementVector = new Vector3(0, 2*impulseForce, 0);
        rotation = bodyToRotate.rotation;
        moveImplemented = false;
    }

    private void RotateLeft(object sender, System.EventArgs e)
    {
        movementVector = new Vector3(0, 0, 0);
        rotation = bodyToRotate.rotation;
        rotation.y += GlobalFixedConstants.degreeToTurnLeft;
        moveImplemented = false;
    }

    private void RotateRight(object sender, System.EventArgs e)
    {
        movementVector = new Vector3(0, 0, 0);
        rotation = bodyToRotate.rotation;
        rotation.y += GlobalFixedConstants.degreeToTurnRight;
        moveImplemented = false;
    }

    private void AddForwardForce(object sender, System.EventArgs e)
    {
        movementVector = new Vector3(0, 0, impulseForce);
        
        rotation = bodyToRotate.rotation;
        moveImplemented = false;
    }

    private void AddBackwardsForce(object sender, System.EventArgs e)
    {
        movementVector = new Vector3(0, 0, -1 * impulseForce);
        rotation = bodyToRotate.rotation;
        moveImplemented = false;
    }

    private void FixedUpdate()
    {
        if (!moveImplemented)
        {
            moveImplemented = true;
            bodyToRotate.Rotate(rotation.x, rotation.y, rotation.z);
            bodyToMove.AddRelativeForce(movementVector, ForceMode.Force);
        }
    }

}
