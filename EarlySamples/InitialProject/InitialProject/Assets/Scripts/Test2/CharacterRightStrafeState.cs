using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRightStrafeState : ICharacterState
{
    private Zombie zombie;
    private Rigidbody ZombieRigidBody;

    public CharacterRightStrafeState(Zombie zombie)
    {
        this.zombie = zombie;
        ZombieRigidBody = zombie.GetComponent<Rigidbody>();
    }

    public string ReturnCurrentState()
    {
        return "RIGHTSTRAFE";
    }

  
    void ICharacterState.FixedUpdate()
    {
        ZombieRigidBody.MovePosition(ZombieRigidBody.position + ZombieRigidBody.transform.right * 1.0f*0.1f);
    }



}
