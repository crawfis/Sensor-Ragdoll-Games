using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIHandler : MonoBehaviour
{
    public Rigidbody rigidbodyToRestart;

    private void OnEnable()
    {
        UIInputHandler.onQuit += UIInputHandlerOnQuitRequested;
        UIInputHandler.onPause += UIInputHandlerPauseRequested;
        UIInputHandler.Restart += UIInputHandlerRestartRequested;
        UIInputHandler.onTakeScreenShot += UIInputHandleronTakeScreenShotRequested;
    }

    private void Awake()
    {
        GlobalFixedConstants.Instance.gamePaused = false;
    }

    private void UIInputHandleronTakeScreenShotRequested(object sender, System.EventArgs e)
    {
    }

    private void UIInputHandlerRestartRequested(object sender, System.EventArgs e)
    {
        rigidbodyToRestart.position = GlobalFixedConstants.Instance.startPosition;
        rigidbodyToRestart.rotation = Quaternion.Euler(0, 0, 0);
        rigidbodyToRestart.velocity = Vector3.zero;
        rigidbodyToRestart.isKinematic = true;
        //reset rotation.
    }

    private void UIInputHandlerPauseRequested(object sender, System.EventArgs e)
    {
        if(GlobalFixedConstants.Instance.gamePaused)
        {
            Time.timeScale = 1;
            GlobalFixedConstants.Instance.gamePaused = false;
        }

        else if(!GlobalFixedConstants.Instance.gamePaused)
        {
            Time.timeScale = 0;
            GlobalFixedConstants.Instance.gamePaused = true;
        }
       
    }

    private void UIInputHandlerOnQuitRequested(object sender, System.EventArgs e)
    {
        //Based on platform, either closes the editor, or the entire application(if fully built)
        #if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;

        #else
                Application.Quit();

        #endif
    }

    


}
