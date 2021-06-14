using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private void Awake()
    {
        GlobalFixedConstants.Instance.grounded = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 3)
        {
            GlobalFixedConstants.Instance.grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.layer == 3)
        {
            GlobalFixedConstants.Instance.grounded = false;
        }
    }
}
