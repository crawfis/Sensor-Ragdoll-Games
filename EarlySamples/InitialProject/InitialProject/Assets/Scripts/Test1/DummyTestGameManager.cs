using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

namespace OhioState.RoadCrossing
{
    //The class that manages the game control
    public class DummyTestGameManager : MonoBehaviour
    {
        private static DummyTestGameManager instance; // the singleton instance of DummyTestGamemanager
        public static DummyTestGameManager Instance{get { return instance; }} // The get property of the singleton
        
        

        private void Awake()
        {

            if(instance != null && instance != this) //eliminate all duplicates of DummyTestGameManager instance
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }

            GetComponent<PlayerInput>().onActionTriggered += DummyTestGameManagerOnActionTriggered; //receive all action triggers from player input
        }


        public static event EventHandler onQuit; // The event to signal Quit
        public static event EventHandler onPause; // The event to signal Pause
        public static event EventHandler onTakeScreenShot; // The event to signal screenshotting
        public static event EventHandler onLeftImpact; // The event to signal player left collison with wall
        public static event EventHandler onRightImpact; // The event to signal player right collision with wall
        public static event EventHandler RunRequest;
        public static event EventHandler WalkRequest;
        public static event EventHandler BackwardsRequest;
        public static event EventHandler StrafeLeftRequest;
        public static event EventHandler GoalReached;
        public static event EventHandler Restart;
        public static event EventHandler Enable;
        public static event EventHandler StopRequest;


        //Handle all action triggers by comparing name, and invoking the appropriate event launch function
        private void DummyTestGameManagerOnActionTriggered(InputAction.CallbackContext obj)
        {
            if (obj.action.name == "Quit")
            {
                OnQuitRequest(); // The function to fire the "Quit" action
            }
        }

        //The function to fire of the Quit request
        private void OnQuitRequest()
        {
            if(onQuit != null)
            {
                onQuit(this, EventArgs.Empty);
            }
        }

        //The function to fire of the leftImpact request
        private void OnLeftImpactRequest()
        {
            if (onLeftImpact != null)
            {
                onLeftImpact(this, EventArgs.Empty);
            }
        }

        //The function to fire of the rightImpact request
        private void OnRightImpactRequest()
        {
            if (onRightImpact != null)
            {
                onRightImpact(this, EventArgs.Empty);
            }
        }

    }
}
