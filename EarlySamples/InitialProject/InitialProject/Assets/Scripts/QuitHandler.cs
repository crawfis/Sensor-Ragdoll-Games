using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace OhioState.RoadCrossing
{
    //The class to handle the event "Quit"
    public class QuitHandler : MonoBehaviour
    {
        public InputActionAsset testActions;
        InputActionMap UIActionMap;
        InputAction quitInputAction;

        private void Start()
        {
            UIActionMap = testActions.FindActionMap("UI");
            quitInputAction = UIActionMap.FindAction("Quit");

            quitInputAction = UIActionMap.FindAction("Quit");
            quitInputAction.performed += HandleQuitRequest;

        }

        private void HandleQuitRequest(InputAction.CallbackContext obj)
        {
            //Based on platform, either closes the editor, or the entire application(if fully built)
            #if UNITY_EDITOR

            UnityEditor.EditorApplication.isPlaying = false;

            #else
                Application.Quit();

            #endif
        }

      
       
    }
}
