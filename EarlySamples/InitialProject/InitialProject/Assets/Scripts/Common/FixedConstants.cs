using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedConstants : MonoBehaviour
{
    // Start is called before the first frame update
    private static FixedConstants instance; // the singleton instance of FixedConstants
    public static FixedConstants Instance { get { return instance; } } // The get property of the singleton


    public static float impulseForce = 300;
    public static float degreeToTurnLeft = -10;
    public static float degreeToTurnRight = 10;

   
}
