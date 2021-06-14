using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
   public enum playerState { Idle,Walking,Running,Jumping,RightStrafe,LeftStrafe};
   private playerState player;

    public PlayerState()
    {
        player = playerState.Walking;
    }
    public void changeToWalk()
    {
        if(player != playerState.Walking)
        {
            player = playerState.Walking;
        }
    }

    public void changeToRun()
    {
        if (player != playerState.Running)
        {
            player = playerState.Running;
        }
    }

    public void changeToJump()
    {
        if (player != playerState.Jumping)
        {
            player = playerState.Jumping;
            GlobalFixedConstants.Instance.grounded = false;
        }
    }

    public void changeToLeftStrafe()
    {
        if (player != playerState.LeftStrafe)
        {
            player = playerState.LeftStrafe;
        }
    }

    public void changeToRightStrafe()
    {
        if (player != playerState.RightStrafe)
        {
            player = playerState.RightStrafe;
        }
    }

    public void changeToIdle()
    {
        if (player != playerState.Idle)
        {
            player = playerState.Idle;
        }
    }

    public playerState returnPlayerState()
    {
        return player;
    }
}
