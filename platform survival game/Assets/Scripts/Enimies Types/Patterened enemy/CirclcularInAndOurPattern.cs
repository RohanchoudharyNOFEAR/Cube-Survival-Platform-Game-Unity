using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclcularInAndOurPattern : MonoBehaviour
{
   
  // [SerializeField]
   // List<Transform> children = new List<Transform>();
   [SerializeField]
    Transform[] children= new Transform[5] ;
    private float frequency = 5f;
    [SerializeField]
    private float magnitude = 2.5f;
    [SerializeField]
    private float offset = 0f;
    [SerializeField]
    private float lerpRadius = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
       // Transform[] children = new Transform[this.transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            children[i] = transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        InAndOutMotion();
    }
    private void InAndOutMotion()
    {
        int i = 0;
        foreach (Transform child in children) { 
           
            float angle = 60f*i;
            //  var rot = Quaternion.AngleAxis(30, Vector3.right);
            // var lDirection = rot * Vector3.forward;
            // Vector3 lDirection = Quaternion.AngleAxis(angle, Vector3.up)*transform.right;
            Vector3 lDirection = RotateTowardsUp(transform.forward, angle)*5f;
            Vector3 interpolatedPosition = Vector3.Lerp(transform.position, lDirection, lerpRadius);
           

         //   Quaternion.AngleAxis(angle, transform.up) * transform.right;
            child.position = interpolatedPosition;
          //  Debug.Log(angle);
          if(i>children.Length)
            {
                i = 0;
            }
            else { i++; }
       
           // child.position = child.position  + child.transform.InverseTransformDirection(Vector3.right) * Mathf.Sin(Time.time * frequency + offset) * magnitude;
           // child.transform.Translate( child.transform.right * Mathf.Sin(Time.time * frequency + offset) * magnitude);
        }
    }
    Vector3 RotateTowardsUp(Vector3 start, float angle)
    {
        // if you know start will always be normalized, can skip this step
        start.Normalize();

        Vector3 axis = Vector3.Cross(start, Vector3.right);

        // handle case where start is colinear with up
        if (axis == Vector3.zero) axis = Vector3.right;

        return Quaternion.AngleAxis(angle, axis) * start;
    }
}

