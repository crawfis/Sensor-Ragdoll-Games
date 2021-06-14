using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{

    float YCenter;float XCenter;float ZCenter;
    float XRange;//float YRange; float ZRange;
    int XDirection = 1;
    int ZDirection = 1;

    //Random random = new Random();

    private void Start()
    {
        YCenter = this.transform.position.y;
        XCenter = this.transform.position.x;
        ZCenter = this.transform.position.z;
        XRange = 20; //YRange = 10; ZRange = 5;
        XDirection = (Random.Range(-50, 50) %2 )*2 -1; 
        ZDirection = 2 * Random.Range(-1, 0) + 1;
    }

    void Update()
    {
        
        //XDirection = (Random.Range(-50, 50) % 2) * 2 - 1;
        this.transform.position = new Vector3(XCenter + XDirection * Mathf.PingPong(Time.time * 2, XRange), this.transform.position.y, this.transform.position.z);
    }
}
