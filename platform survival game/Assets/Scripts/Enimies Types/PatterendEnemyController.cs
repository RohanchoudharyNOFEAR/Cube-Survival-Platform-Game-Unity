using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatterendEnemyController : MonoBehaviour
{

    [SerializeField]
    private float speed;

    [SerializeField]
    private int damage;

    [SerializeField]
    private float RotationSpeed=20f;


    // [SerializeField]
    // private EnemyDataSO data;
    [SerializeField]
    private PatternEnemiesDataSO data;


    public GameObject Player;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        StraightMovement();
    }

    void Rotate()
    {
        transform.Rotate(0, RotationSpeed * Time.deltaTime, 0);
    }


    void StraightMovement()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
