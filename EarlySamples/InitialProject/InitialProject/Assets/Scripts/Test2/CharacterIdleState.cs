using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIdleState : ICharacterState
{
    private Zombie zombie;
    private Rigidbody CharacterRigidBody;

    public CharacterIdleState(Zombie zombie)
    {
        this.zombie = zombie;
        CharacterRigidBody = zombie.GetComponent<Rigidbody>();
    }

    public string ReturnCurrentState()
    {
        return "IDLE";
    }

    void ICharacterState.FixedUpdate()
    {
        CharacterRigidBody.MovePosition(CharacterRigidBody.position + CharacterRigidBody.transform.forward * GlobalFixedConstants.IdleForce);
    }
}
