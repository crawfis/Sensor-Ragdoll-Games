using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OhioState.RoadCrossing
{
    //The class to handle the collison of player with the surrounding walls
    public class TestPlayerImpact : MonoBehaviour
    {
        private GameObject player;
        
        void Start()
        {
            DummyTestGameManager ImpactHandler = DummyTestGameManager.Instance; // get the singleton instance of the DummyTestGameManager
            ImpactHandler.onRightImpact += ImpactHandlerOnRightImpact; // Subscribe to the event "OnrightImpact"
            ImpactHandler.onLeftImpact += ImpactHandlerOnLeftImpact; // Subscribe to the event "OnleftImpact"
            player = GameObject.FindGameObjectWithTag("Player"); //the reference to player to add force on impact
        }

        private void ImpactHandlerOnLeftImpact(object sender, System.EventArgs e)
        {
            //directly add force to the cube?
            
            player.GetComponent<Rigidbody>().AddForce(new Vector3(5, 5));
        }

        private void ImpactHandlerOnRightImpact(object sender, System.EventArgs e)
        {
            //directly add force to the cube?
            player.GetComponent<Rigidbody>().AddForce(new Vector3(-5, 5));
        }
    }
}
