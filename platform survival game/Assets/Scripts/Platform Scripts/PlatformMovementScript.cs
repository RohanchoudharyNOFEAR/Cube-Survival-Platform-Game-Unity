using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovementScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setPosition();
        setRotation();
    }

    void setPosition()
    {
        transform.position = new Vector3(0f, 0f, 0f);
    }

    void setRotation()
    {
        transform.rotation = new Quaternion(0,0,0,0);
    }

}
