using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParentForwardMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StraightMovement();
        DestroyGameobject();
    }
    void StraightMovement()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void DestroyGameobject()
    {
        Destroy(this.gameObject, 10f);
    }

}
