using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMovement 
{
    private Rigidbody rigidbodyToMove;

    public DefaultMovement(Rigidbody rigidbody)
    {
        rigidbodyToMove = rigidbody;
    }

    public void FixedUpdate()
    {
        if(GlobalFixedConstants.Instance.grounded)
        {
            rigidbodyToMove.AddRelativeForce(new Vector3(0, 0, GlobalFixedConstants.defaultForce), ForceMode.Force);
        }
           
    }

}
