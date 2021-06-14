using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFixedConstants : MonoBehaviour
{
    private static GlobalFixedConstants instance; // the singleton instance of DummyTestGamemanager
    public static GlobalFixedConstants Instance { get { return instance; } } // The get property of the singleton

    public const float impulseForce = 300;
    public const float defaultForce = 7;
    public const float degreeToTurnLeft = -10;
    public const float degreeToTurnRight = 10;
    public Vector3 startPosition = new Vector3(0, 15, -97.2f);
    public bool gamePaused;
    public bool ground;
    public bool gamePause { get
        { return gamePaused; }
        set { gamePaused = value; } }

    public bool grounded
    {
        get
        { return ground; }
        set { ground = value; }
    }

    public void Awake()
    {

        if (instance != null && instance != this) //eliminate all duplicates of DummyTestGameManager instance
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

    }


}
