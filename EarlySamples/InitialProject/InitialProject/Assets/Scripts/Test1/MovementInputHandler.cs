   using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace OhioState.RoadCrossing
{

    public class MovementInputHandler : MonoBehaviour
    {
        private Rigidbody rigidBody;
        private Vector2 movementVector;
        [SerializeField] float speed = 10;
        [SerializeField] Rigidbody rigidBodyToMove;

        //void Start()
        //{
        //    rigidBodyToMove = GetComponent<Rigidbody>();
        //}

        public void OnMove(InputValue movementValue)
        {
            movementVector = movementValue.Get<Vector2>();
        }

        private void FixedUpdate()
        {
            Vector3 movement = new Vector3(movementVector.x, 0, movementVector.y);
            rigidBodyToMove.AddForce(movement * speed);
        }
    }

}

