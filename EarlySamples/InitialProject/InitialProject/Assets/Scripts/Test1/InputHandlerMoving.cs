using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace OhioState.RoadCrossing
{
    public class InputHandlerMoving : MonoBehaviour
    {
        public InputActionAsset testActions;
        InputActionMap keyboardActionMap;
        InputAction jumpInputAction;
        InputAction moveLeftAction;
        InputAction moveRightAction;
        InputAction moveUpAction;
        InputAction moveDownAction;
        Rigidbody player;
        Vector3 movementVector;
        [SerializeField]private float impulseForce = 100;
        [SerializeField]private GameObject bodyToAnimate;
        [SerializeField]private Rigidbody bodyToMove;
        bool moveImplemented;

        //[SerializeField] EventStarTrekBeamDown spawner;

        private void Awake()
        {
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

            movementVector = Vector3.zero;
            player = GetComponent<Rigidbody>();
            moveImplemented = true;
            
        }


        private void HandleMoveDownEvent(InputAction.CallbackContext obj)
        {
            
            movementVector = new Vector3(0, 0, -1*impulseForce);
            moveImplemented = false;
            //call change to movedownanimation (either raise an event 
        }

        private void HandleMoveUpEvent(InputAction.CallbackContext obj)
        {
            movementVector = new Vector3(0, 0, impulseForce);
            moveImplemented = false;
        }

        private void HandleMoveLeftEvent(InputAction.CallbackContext obj)
        {
            movementVector = new Vector3(-1*impulseForce, 0, 0);
            moveImplemented = false;
        }

        private void HandleMoveRightEvent(InputAction.CallbackContext obj)
        {
            movementVector = new Vector3(impulseForce, 0, 0);
            moveImplemented = false;
        }

        private void HandleJumpInputEvent(InputAction.CallbackContext obj)
        {
            movementVector = new Vector3(0, impulseForce, 0);
            moveImplemented = false;
        }

        private void FixedUpdate()
        {
            if(!moveImplemented)
            {
                moveImplemented = true;
                player.AddForce(movementVector, ForceMode.Force);
            }
        }

    }
}



