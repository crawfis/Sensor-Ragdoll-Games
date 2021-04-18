using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class TestPlayerInputManager : MonoBehaviour
{
    private static TestPlayerInputManager instance; // the singleton instance of DummyTestGamemanager
    public static TestPlayerInputManager Instance { get { return instance; } } // The get property of the singleton

    public InputActionAsset testActions;
    InputActionMap keyboardActionMap;
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

    private void Awake()
    {
        if (instance != null && instance != this) //eliminate all duplicates of DummyTestGameManager instance
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        keyboardActionMap = testActions.FindActionMap("Player");
        moveLeftAction = keyboardActionMap.FindAction("MoveLeft");
        moveRightAction = keyboardActionMap.FindAction("MoveRight");
        moveUpAction = keyboardActionMap.FindAction("MoveUp");
        moveDownAction = keyboardActionMap.FindAction("MoveDown");
        jumpInputAction = keyboardActionMap.FindAction("Jump");

        jumpInputAction.performed += HandleJumpInputEvent;
        moveRightAction.performed += HandleMoveRightEvent;
        moveLeftAction.performed += HandleMoveLeftEvent;
        moveUpAction.performed += HandleMoveUpEvent;
        moveDownAction.performed += HandleMoveDownEvent;

    }

    private void HandleMoveDownEvent(InputAction.CallbackContext obj)
    {
        moveDown(this, EventArgs.Empty);
    }

    private void HandleMoveUpEvent(InputAction.CallbackContext obj)
    {
        moveUp(this, EventArgs.Empty);
    }

    private void HandleMoveLeftEvent(InputAction.CallbackContext obj)
    {
        moveLeft(this, EventArgs.Empty);
    }

    private void HandleMoveRightEvent(InputAction.CallbackContext obj)
    {
        moveRight(this, EventArgs.Empty);
    }

    private void HandleJumpInputEvent(InputAction.CallbackContext obj)
    {
        jump(this, EventArgs.Empty);
    }

    //Handle all action triggers by comparing name, and invoking the appropriate event launch function
    

    //The function to fire of the leftImpact request
    private void OnLeftImpactRequest()
    {
        if (onLeftImpact != null)
        {
            onLeftImpact(this, EventArgs.Empty);
        }
    }

    //The function to fire of the rightImpact request
    private void OnRightImpactRequest()
    {
        if (onRightImpact != null)
        {
            onRightImpact(this, EventArgs.Empty);
        }
    }

}
