using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform Player;
    [SerializeField]
    private float _smoothTime;
    private Vector3 _currentVelocity = Vector3.zero;
    private Vector3 _offSet;

    // Start is called before the first frame update
    void Start()
    {
         _offSet = transform.position - Player.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        playerFollow();
    }


    void playerFollow()
    {
     
        var TargetedPosition = Player.position + _offSet;
        transform.position = Vector3.SmoothDamp(transform.position, TargetedPosition, ref _currentVelocity , _smoothTime);
      //  transform.position = Player.position - transform.position;
    }

}
