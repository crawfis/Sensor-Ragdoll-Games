using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GTMY.Audio;

public class CharacterWalkingState : ICharacterState
{
    private Zombie zombie;
    private Rigidbody ZombieRigidBody;

    public CharacterWalkingState(Zombie zombie)
    {
        this.zombie = zombie;
        ZombieRigidBody = zombie.GetComponent<Rigidbody>();
    }

    public string ReturnCurrentState()
    {
        return "WALKING";
    }

    void ICharacterState.FixedUpdate()
    {
        ZombieRigidBody.MovePosition(ZombieRigidBody.position + ZombieRigidBody.transform.forward * GlobalFixedConstants.WalkingForce);
        
    }

}
