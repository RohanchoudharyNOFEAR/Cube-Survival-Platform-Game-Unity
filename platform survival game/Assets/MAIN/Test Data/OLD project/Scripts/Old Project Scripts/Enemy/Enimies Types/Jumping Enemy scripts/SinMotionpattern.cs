using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMotionpattern : MonoBehaviour
{
    public float speedOnZ; //this t on the your picture
    //not sure how the parametrs are exactly named
    public float amplitude;
    public float frequency;
    public float magnitude;
    private float offset;

    float z, y;
    private void Update()
    {
        /*
        z = transform.position.z +speedOnZ * Time.deltaTime;
        y = Mathf.Abs( Mathf.Sin(z * frequency) * amplitude);
        transform.localPosition = new Vector3(0,y,z*Time.deltaTime);
        */

        z = 2f;
        y = Mathf.Abs(Mathf.Sin(transform.parent.position.z * frequency) * amplitude);
        transform.localPosition = new Vector3(0, y, 0 );


        /*
        z = z + speedOnZ * Time.deltaTime;
        y = Mathf.Abs(Mathf.Sin(Time.time* frequency) * amplitude);
       
        transform.localPosition = new Vector3(0, y, z);

        */
        // Vector3 z = transform.forward * speedOnZ * Time.deltaTime;
        // Vector3 y = transform.up* Mathf.Abs(Mathf.Sin(Time.time * frequency + offset) * amplitude);
        // transform.localPosition =  z+y;



    }



 }


//rough
/*
       z = z + speedOnZ * Time.deltaTime;
       y = Mathf.Abs(Mathf.Sin(Time.time* frequency) * amplitude);

       transform.localPosition = new Vector3(0, y, z);

       */
// Vector3 z = transform.forward * speedOnZ * Time.deltaTime;
// Vector3 y = transform.up* Mathf.Abs(Mathf.Sin(Time.time * frequency + offset) * amplitude);
// transform.localPosition =  z+y;

