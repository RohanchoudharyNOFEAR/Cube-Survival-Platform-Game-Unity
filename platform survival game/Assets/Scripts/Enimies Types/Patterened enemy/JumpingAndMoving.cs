using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingAndMoving : MonoBehaviour
{
    Vector3 startingpos;
    [SerializeField]
    private float frequency = 5f;
    [SerializeField]
    private float magnitude = 5f;
    [SerializeField]
    private float offset = 0f;
    // Start is called before the first frame update
    void Start()
    {
        startingpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startingpos + transform.up * Mathf.Sin(Time.time * frequency + offset) * magnitude;
    }
}
