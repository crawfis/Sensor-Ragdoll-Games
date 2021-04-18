using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIHandler : MonoBehaviour
{

    private void OnEnable()
    {
        UIInputHandler.onQuit += UIInputHandlerOnQuitRequested;
        UIInputHandler.onPause += UIInputHandlerPauseRequested;
        UIInputHandler.Restart += UIInputHandlerRestartRequested;
        UIInputHandler.onTakeScreenShot += UIInputHandleronTakeScreenShotRequested;
    }

    private void UIInputHandleronTakeScreenShotRequested(object sender, System.EventArgs e)
    {
    }

    private void UIInputHandlerRestartRequested(object sender, System.EventArgs e)
    {
    }

    private void UIInputHandlerPauseRequested(object sender, System.EventArgs e)
    {
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
