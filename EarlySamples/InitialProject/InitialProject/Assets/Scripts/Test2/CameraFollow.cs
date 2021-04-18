using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    private Vector3 cameraOffset;

    private float smoothFactor = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newposition = target.transform.position + cameraOffset;
        //transform.position = Vector3.Slerp(transform.position, newposition,smoothFactor);
        transform.position = newposition;
       //transform.LookAt(target);
        
    }
}
