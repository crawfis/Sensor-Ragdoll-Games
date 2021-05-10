using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
   public enum playerState { Idle,Walking,Running,Jumping};
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
        }
    }

    public playerState returnPlayerState()
    {
        return player;
    }
}
