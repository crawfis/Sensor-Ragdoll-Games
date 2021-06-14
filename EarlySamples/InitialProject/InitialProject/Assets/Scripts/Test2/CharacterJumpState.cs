using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class CharacterJumpState : ICharacterState
{
    private Zombie zombie;
    private ICharacterState PreviousState;
    private Rigidbody CharacterRigidBody;
    private Vector3 JumpPoint;
    private bool MovingUp;

    public CharacterJumpState(Zombie zombie, ICharacterState PreviousState)
    {
        this.zombie = zombie;
        this.PreviousState = PreviousState;
        CharacterRigidBody = zombie.GetComponent<Rigidbody>();
        JumpPoint = CharacterRigidBody.position + new Vector3(0, 8, 0);
        MovingUp = true;
    }

    public string ReturnCurrentState()
    {
        return "JUMPING";
    }

    public void FixedUpdate()
    {
        Vector3 MovementAddition = Vector3.zero;
        if(PreviousState.ReturnCurrentState().Equals("WALKING"))
        {
            MovementAddition = CharacterRigidBody.transform.forward * GlobalFixedConstants.WalkingForce;
        }

        else if(PreviousState.ReturnCurrentState().Equals("RUNNING"))
        {
            MovementAddition = CharacterRigidBody.transform.forward * GlobalFixedConstants.RunningForce;
        }

        else if (PreviousState.ReturnCurrentState().Equals("RIGHTSTRAFE"))
        {
            MovementAddition = CharacterRigidBody.transform.right * 1.0f*0.1f;
        }

        else if (PreviousState.ReturnCurrentState().Equals("LEFTSTRAFE"))
        {
            MovementAddition = CharacterRigidBody.transform.right * -1.0f*0.1f;
        }

        if (CharacterRigidBody.position.y<=JumpPoint.y && MovingUp)
        {
            CharacterRigidBody.MovePosition(CharacterRigidBody.position + CharacterRigidBody.transform.up * 0.5f*0.5f + MovementAddition);
        }

        else
        {
            MovingUp = false;
            zombie.ChangeToMoveDown();
            CharacterRigidBody.MovePosition(CharacterRigidBody.position + CharacterRigidBody.transform.up * -0.5f*0.5f + MovementAddition);
        }
    }

}

