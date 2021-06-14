using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterRunningState : ICharacterState
{
    private Zombie zombie;
    private Rigidbody ZombieRigidBody;


    public CharacterRunningState(Zombie zombie)
    {
        this.zombie = zombie;
        ZombieRigidBody = zombie.GetComponent<Rigidbody>();
    }

    void ICharacterState.FixedUpdate()
    {
        ZombieRigidBody.MovePosition(ZombieRigidBody.position + ZombieRigidBody.transform.forward * GlobalFixedConstants.RunningForce);
        
    }

    public string ReturnCurrentState()
    {
        return "RUNNING";
    }
}
