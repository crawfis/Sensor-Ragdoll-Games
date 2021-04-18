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
        impulseForce = FixedConstants.impulseForce;
    }

    private void OnEnable()
    {
        TestPlayerInputManager.moveDown += TestPlayerInputManagerMoveDown;
        TestPlayerInputManager.moveUp += TestPlayerInputManagerMoveUp;
        TestPlayerInputManager.moveRight += TestPlayerInputManagerMoveRight;
        TestPlayerInputManager.moveLeft += TestPlayerInputManagerMoveLeft;
        TestPlayerInputManager.jump += TestPlayerInputManagerJump;
    }

    private void TestPlayerInputManagerJump(object sender, System.EventArgs e)
    {
        movementVector = new Vector3(0,impulseForce,0);
        rotation = bodyToRotate.rotation;
        moveImplemented = false;
    }

    private void TestPlayerInputManagerMoveLeft(object sender, System.EventArgs e)
    {
        movementVector = new Vector3(-1 * impulseForce, 0, 0);
        rotation = bodyToRotate.rotation;
        //rotation.y += FixedConstants.degreeToTurnLeft;
        moveImplemented = false;
    }

    private void TestPlayerInputManagerMoveRight(object sender, System.EventArgs e)
    {
        movementVector = new Vector3(impulseForce,0,0);
        rotation = bodyToRotate.rotation;
        //rotation.y += FixedConstants.degreeToTurnRight;
        moveImplemented = false;
    }

    private void TestPlayerInputManagerMoveUp(object sender, System.EventArgs e)
    {
        movementVector = new Vector3(0, 0, impulseForce);
        rotation = bodyToRotate.rotation;
        moveImplemented = false;
    }

    private void TestPlayerInputManagerMoveDown(object sender, System.EventArgs e)
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
            bodyToMove.AddForce(movementVector, ForceMode.Force);
        }
    }

}
