using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class TestPlayerInputManager
{
   

    public InputActionAsset testActions;
    InputAction jumpInputAction;
    InputAction moveLeftAction;
    InputAction moveRightAction;
    InputAction moveUpAction;
    InputAction moveDownAction;

    public static event EventHandler onLeftImpact; // The event to signal player left collison with wall
    public static event EventHandler onRightImpact; // The event to signal player right collision with wall
    public static event EventHandler RunRequest;
    public static event EventHandler WalkRequest;
    public static event EventHandler BackwardsRequest;
    public static event EventHandler StrafeLeftRequest;
    public static event EventHandler StrafeRightRequest;

    public static event EventHandler moveLeft;
    public static event EventHandler moveRight;
    public static event EventHandler moveUp;
    public static event EventHandler moveDown;
    public static event EventHandler jump;


    public  TestPlayerInputManager(InputActionMap playerMovementMap)
    {
        moveLeftAction = playerMovementMap.FindAction("MoveLeft");
        moveRightAction = playerMovementMap.FindAction("MoveRight");
        moveUpAction = playerMovementMap.FindAction("MoveUp");
        moveDownAction = playerMovementMap.FindAction("MoveDown");
        jumpInputAction = playerMovementMap.FindAction("Jump");

        jumpInputAction.performed += HandleJumpInputEvent;
        moveRightAction.performed += HandleMoveRightEvent;
        moveLeftAction.performed += HandleMoveLeftEvent;
        moveUpAction.performed += HandleMoveUpEvent;
        moveDownAction.performed += HandleMoveDownEvent;

    }

    private void HandleMoveDownEvent(InputAction.CallbackContext obj)
    {
        if (GlobalFixedConstants.Instance.grounded)
        { moveDown(this, EventArgs.Empty); }
    }

    private void HandleMoveUpEvent(InputAction.CallbackContext obj)
    {
        if (GlobalFixedConstants.Instance.grounded)
        { moveUp(this, EventArgs.Empty); }
    }

    private void HandleMoveLeftEvent(InputAction.CallbackContext obj)
    {
        StrafeLeftRequest(this, EventArgs.Empty);
    }

    private void HandleMoveRightEvent(InputAction.CallbackContext obj)
    {
        StrafeRightRequest(this, EventArgs.Empty);
    }

    private void HandleJumpInputEvent(InputAction.CallbackContext obj)
    {
        if(GlobalFixedConstants.Instance.grounded)
        {
            jump(this, EventArgs.Empty);
        }
        
    }

}
