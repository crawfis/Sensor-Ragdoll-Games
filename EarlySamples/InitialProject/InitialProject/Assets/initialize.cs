using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class initialize : MonoBehaviour
{

    [SerializeField] private InputActionAsset PlayerAsset;
    [SerializeField] private InputActionAsset UIAsset;
    [SerializeField] private string inputUIMapName = "UI";
    [SerializeField] private string inputPlayerMovementMapName = "Player";
    [SerializeField] private Rigidbody rigidbodyToMove;
    DefaultMovement defaultMovement;

    private void Start()
    {
        InputActionMap UIActionMap = UIAsset.FindActionMap(inputUIMapName);
        UIInputHandler uIInputHandler = new UIInputHandler(UIActionMap);

        InputActionMap PlayerMovementMap = PlayerAsset.FindActionMap(inputPlayerMovementMapName);
        TestPlayerInputManager playerMovementInputHandler = new TestPlayerInputManager(PlayerMovementMap);

        defaultMovement = new DefaultMovement(rigidbodyToMove);

    }

    private void FixedUpdate()
    {
        defaultMovement.FixedUpdate();
    }

}
