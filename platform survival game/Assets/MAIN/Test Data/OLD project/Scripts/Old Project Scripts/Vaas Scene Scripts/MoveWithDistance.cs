using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithDistance : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private GameObject startingpos;
    [SerializeField]
    private GameObject endingpos;
    [SerializeField]
    private float lerppct=0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveAccToPlayerDistance();
    }
    void MoveAccToPlayerDistance()
    {
        float distance = Vector3.Distance(endingpos.transform.position, player.position);
        lerppct = distance;
        Debug.Log(lerppct + "lerp");
        Debug.Log(distance + "distance");
        transform.position = Vector3.LerpUnclamped(startingpos.transform.position, endingpos.transform.position,lerppct);
    }
}
/*
       Vector3 Direction = player.transform.position - transform.position;
       float distance= Vector3.Distance(transform.position,player.position) ;
       //Debug.Log(distance);
       float multiplier = 30 / distance;
       transform.Translate(-Vector3.right*multiplier*Time.deltaTime);
       */
