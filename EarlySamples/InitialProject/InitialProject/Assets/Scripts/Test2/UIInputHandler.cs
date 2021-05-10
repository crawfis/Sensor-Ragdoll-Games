using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class UIInputHandler
{

   
    InputAction quitAction;
    InputAction pauseAction;
    InputAction takeScreenShotAction;
    InputAction restartAction;

    public static event EventHandler onQuit; // The event to signal Quit
    public static event EventHandler onPause; // The event to signal Pause
    public static event EventHandler onTakeScreenShot; // The event to signal screenshotting
    public static event EventHandler GoalReached;
    public static event EventHandler Restart;
    public static event EventHandler Enable;
    public static event EventHandler StopRequest;

    public  UIInputHandler(InputActionMap UIActionMap)
    {
        quitAction = UIActionMap.FindAction("Quit");
        pauseAction = UIActionMap.FindAction("Pause");
        takeScreenShotAction = UIActionMap.FindAction("Screenshot");
        restartAction = UIActionMap.FindAction("Restart");

        quitAction.performed += QuitActionRequested;
        pauseAction.performed += PauseActionRequested;
        takeScreenShotAction.performed += TakeScreenShotActionRequested;
        restartAction.performed += RestartActionRequested;

    }

    private void RestartActionRequested(InputAction.CallbackContext obj)
    {
        Restart(this, EventArgs.Empty);
    }

    private void TakeScreenShotActionRequested(InputAction.CallbackContext obj)
    {
        onTakeScreenShot(this, EventArgs.Empty);
    }

    private void PauseActionRequested(InputAction.CallbackContext obj)
    {
        onPause(this, EventArgs.Empty);
    }

    private void QuitActionRequested(InputAction.CallbackContext obj)
    {
        onQuit(this, EventArgs.Empty);
    }

    
}
