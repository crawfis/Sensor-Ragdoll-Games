using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLeftStrafeState : ICharacterState
{
    private Zombie zombie;
    private Rigidbody ZombieRigidBody;

    public CharacterLeftStrafeState(Zombie zombie)
    {
        this.zombie = zombie;
        ZombieRigidBody = zombie.GetComponent<Rigidbody>();
    }
    public string ReturnCurrentState()
    {
        return "LEFTSTRAFE";
    }

    void ICharacterState.FixedUpdate()
    {
        ZombieRigidBody.MovePosition(ZombieRigidBody.position + ZombieRigidBody.transform.right * -1.0f*0.1f);
    }
}
