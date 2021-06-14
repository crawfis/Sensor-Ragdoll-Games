
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieRagdoll : MonoBehaviour
{

    PlayerState playerstate = new PlayerState();
    Vector3 MovementVectorPerState;
    [SerializeField] private Animation playerAnimation; 
    [SerializeField] private Rigidbody ZombieRigidBody;
    [SerializeField] private Collider ZombieCollider;
    ICharacterState PreviousState;
    Vector3 JumpPoint;
    Vector3 StrafePoint;
    bool MovingUp;
    bool Ragdoll;
    bool InRagdoll;
    bool ResetAfterJump;
    public ICharacterState state;
    private bool Grounded;
    private bool JumpGrounded;

    private void Awake()
    {
        GlobalFixedConstants.Instance.grounded = true;
        TestPlayerInputManager.moveUp += ChangeStateForward;
        TestPlayerInputManager.moveDown += ChangeStateBackward;
        TestPlayerInputManager.StrafeRightRequest += ChangeStateRightStrafe;
        TestPlayerInputManager.StrafeLeftRequest += ChangeStateLeftStrafe;
        TestPlayerInputManager.jump += ChangeStateJump;
        MovementVectorPerState = new Vector3(0, 0, GlobalFixedConstants.WalkingForce);
        //state = new CharacterWalkingState(this);
        Ragdoll = false;
        InRagdoll = false;
        ResetAfterJump = false;
    }

    /*Jump call*/
    private void ChangeStateJump(object sender, System.EventArgs e)
    {
        if (!state.ReturnCurrentState().Equals("JUMPING"))
        {
            JumpPoint = ZombieRigidBody.position;
            MovingUp = true;
            PreviousState = state;
            //state = new CharacterJumpState(this, state);
            JumpGrounded = false;
            StartCoroutine(ChangeBackFromJump());
        }
    }
    bool DelegateForJumpLimit()
    {
        //if (ZombieRigidBody.transform.position.y <= JumpPoint.y &&!MovingUp)
            if(JumpGrounded && !MovingUp)
        {
            JumpPoint = Vector3.zero;
            return true;
        }

        else
        {
            return false;
        }
    }
    IEnumerator ChangeBackFromJump()
    {
        yield return new WaitUntil(DelegateForJumpLimit);
        ResetAfterJump = true;
        state = PreviousState;
    }
    public void ChangeToMoveDown()
    {
        MovingUp = false;
    }

    /*Ragdoll impact*/

    bool DelegateForRagdollDone()
    {
        return Grounded;
    }

    IEnumerator ChangeBackFromRagdoll(Vector3 RestartPosition)
    {
        yield return null;
        ZombieRigidBody.AddForce(new Vector3(0, 3000, 0), ForceMode.Impulse);
        Grounded = false;
        yield return new WaitUntil(DelegateForRagdollDone);
        InRagdoll = false;
        ZombieRigidBody.isKinematic = true;
        ZombieCollider.isTrigger = true;
        ZombieRigidBody.position = RestartPosition;
        playerAnimation.clip = GlobalFixedConstants.Instance.Gettingup;
        playerAnimation.Play();
        //state = new CharacterIdleState(this);
        Invoke(nameof(ChangeToWalking), 3.0f);
        
    }
    public void ChangeToWalking()
    {
        //state = new CharacterWalkingState(this);
        playerAnimation.clip = GlobalFixedConstants.Instance.ZombieWalking;
        playerAnimation.Play();
    }

    /*Right strafe call*/
    public void ChangeStateRightStrafe(object sender, System.EventArgs e)
    {
        if (!state.ReturnCurrentState().Equals("JUMPING"))
        {
            //state = new CharacterRightStrafeState(this);
            playerAnimation.clip = GlobalFixedConstants.Instance.ZombieIdle;
            playerAnimation.Play();
        }

    }

    /*Left strafe call*/
    public void ChangeStateLeftStrafe(object sender, System.EventArgs e)
    {
        if (!state.ReturnCurrentState().Equals("JUMPING"))
        {
            //state = new CharacterLeftStrafeState(this);
            playerAnimation.clip = GlobalFixedConstants.Instance.ZombieIdle;
            playerAnimation.Play();
        }
    }

    /*backward call*/
    public void ChangeStateBackward(object sender, System.EventArgs e)
    {
        if (state.ReturnCurrentState().Equals("WALKING") || state.ReturnCurrentState().Equals("RIGHTSTRAFE") || state.ReturnCurrentState().Equals("LEFTSTRAFE"))
        {
            //state = new CharacterIdleState(this);
            playerAnimation.clip = GlobalFixedConstants.Instance.ZombieIdle;
            playerAnimation.Play();
        }

        else if (state.ReturnCurrentState().Equals("RUNNING"))
        {
            //state = new CharacterWalkingState(this);
            playerAnimation.clip = GlobalFixedConstants.Instance.ZombieWalking;
            playerAnimation.Play();
        }

    }

    /*forward call*/
    public void ChangeStateForward(object sender, System.EventArgs e)
    {
        if(state.ReturnCurrentState().Equals("IDLE") || state.ReturnCurrentState().Equals("RIGHTSTRAFE") || state.ReturnCurrentState().Equals("LEFTSTRAFE"))
        {
            //state = new CharacterWalkingState(this);
            playerAnimation.clip = GlobalFixedConstants.Instance.ZombieWalking;
            playerAnimation.Play();
        }

        else if (state.ReturnCurrentState().Equals("WALKING"))
        {
            //state = new CharacterRunningState(this);
            playerAnimation.clip = GlobalFixedConstants.Instance.ZombieRunning;
            playerAnimation.Play();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.layer == 6)
        {
            //state = new CharacterIdleState(this);
            ZombieRigidBody.isKinematic = false;
            Ragdoll = true;
            ZombieCollider.isTrigger = false;
        }

        if (collider.gameObject.layer == 3)
        {
            JumpGrounded = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 3)
        {
            Grounded = true;
            JumpGrounded = true;
        }
    }

    private void FixedUpdate()
    {
        if (ResetAfterJump)
        {
            //ZombieRigidBody.MovePosition(new Vector3(ZombieRigidBody.position.x, 0, ZombieRigidBody.position.z));
            //ResetAfterJump = false;
        }

        if(InRagdoll)
        {}
        else if(!Ragdoll)
        {
            state.FixedUpdate(); }
        
        else if(Ragdoll)
        {
            Vector3 RestartPosition = new Vector3(0, 0, -97.2f);
            playerAnimation.clip = GlobalFixedConstants.Instance.RagdollState;
            playerAnimation.Play();
            ZombieRigidBody.useGravity = true;
            Ragdoll = false;
            InRagdoll = true;
            StartCoroutine(ChangeBackFromRagdoll(RestartPosition));
        }
    }
        
}
