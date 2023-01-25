using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclcularPatternCreater : MonoBehaviour
{
    [SerializeField]
    private int NoOFEnemies = 5;
    [SerializeField]
    private float radius = 3f;
    [SerializeField]
    private GameObject EnemyPrefab;


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i< NoOFEnemies;i++)
        {
            float angle = i * Mathf.PI * 2 / NoOFEnemies;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            Vector3 pos = transform.position + new Vector3(x, 0, z);
            float angleDegree = -angle * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(0, angleDegree, 0);
            Instantiate(EnemyPrefab, pos, rot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
