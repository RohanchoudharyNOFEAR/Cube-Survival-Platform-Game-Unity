using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetedEnemyController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private int damage;


    // [SerializeField]
    // private EnemyDataSO data;
    [SerializeField]
    private TargetedEnemyDataSO data;


    public GameObject Player;

   

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Followplayer();
        DestroyGameobject();
    }

    void Followplayer()
    {  
             transform.position = Vector3.MoveTowards(transform.position, Player.transform.position,speed*Time.deltaTime);     
    }
    private void DestroyGameobject()
    {
        Destroy(this.gameObject, 5.5f);
    }




}
