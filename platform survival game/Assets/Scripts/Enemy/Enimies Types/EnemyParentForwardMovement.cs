using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParentForwardMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private Transform _playerTransform;
    public Vector3 MovementDir ;

    // Start is called before the first frame update
    void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
      //  MovementDir = transform.position;
       // setMovementTowardPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        StraightMovement();
        DestroyGameobject();
    }
    void StraightMovement()
    {
        
        transform.Translate(MovementDir * speed * Time.deltaTime);
        //  transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void DestroyGameobject()
    {
        Destroy(this.gameObject, 10f);
    }

    void setMovementTowardPlayer()
    {
        if (_playerTransform != null)
        {
            //for forwrad backward
            if (transform.position.z < _playerTransform.position.z)
            {
                MovementDir = transform.forward;
            }
            else if (transform.position.z > _playerTransform.position.z)
            {
                MovementDir = -transform.forward;
            }

            /*
            //for left right
            if (transform.position.x < _playerTransform.position.x)
            {
                MovementDir = transform.right;
            }
            else if (transform.position.x > _playerTransform.position.x)
            {
                MovementDir = -transform.right;
            }*/
        }
    }
}
