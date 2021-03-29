using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OhioState.RoadCrossing
{
    //The class to handle the event "Quit"
    public class QuitHandler : MonoBehaviour
    {
        private void Start()
        {
            DummyTestGameManager QuitHandler = DummyTestGameManager.Instance; // Get the instance of DummyTestGameManager 
            QuitHandler.onQuit += QuitHandler_Onquit; // Subscribe to the OnQuit event from the instance
        }

        //Hnadles the Quit event.
        private void QuitHandler_Onquit(object sender, System.EventArgs e)
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
