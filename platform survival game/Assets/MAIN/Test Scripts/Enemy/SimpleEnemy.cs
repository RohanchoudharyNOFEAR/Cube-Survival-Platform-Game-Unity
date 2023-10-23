using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestOnly
{
    public class SimpleEnemy : MonoBehaviour
    {
        [SerializeField]
        private float speed;

        [SerializeField]
        private int damage;


        // [SerializeField]
        // private EnemyDataSO data;
        [SerializeField]
        private RandomMovementEnemySO data;


        public GameObject Player;



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            StraightMovement();

        }

        void StraightMovement()
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

    }
}