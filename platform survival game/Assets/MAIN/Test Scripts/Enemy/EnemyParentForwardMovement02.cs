using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace TestOnly
{
    public class EnemyParentForwardMovement02 : Enemy
    {
        [Header("Network Prefab")]
        public GameObject prefab;
        //  public NetworkObject networkObject;

        [SerializeField]
        private float speed = 5f;
        [SerializeField]
        private Transform _playerTransform;
        public Vector3 MovementDir;

        private void Awake()
        {
            //_playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        // Start is called before the first frame update
        void Start()
        {
          
            _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

            //  MovementDir = transform.position;
            // setMovementTowardPlayer();
        }
        private void OnEnable()
        {
           // Invoke("DestroyGameobject", 10f);
        }

        // Update is called once per frame
        void Update()
        {
            StraightMovement();
            //  DestroyGameobject();
        }
        void StraightMovement()
        {

            transform.Translate(MovementDir * speed * Time.deltaTime);
            //  transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        //worked withot error beacuse called at enemy spawner when we spawn this enemy
        private void DestroyGameobject()
        {

            if (NetworkObjectPool.Singleton != null)
            {
                //  prefab.SetActive(false);
                NetworkObject.gameObject.SetActive(false);
                NetworkObjectPool.Singleton.ReturnNetworkObject(NetworkObject, prefab);
              
                if (NetworkObject.IsSpawned)
                {

                  
                      NetworkObject.Despawn(false);

                }
            }

            // Destroy(this.gameObject, 10f);
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

         IEnumerator WaitToDestroy()
        {
            yield return new WaitForSeconds(10);
            DestroyGameobject();
            yield return null;
            //StopCoroutine(WaitToDestroy());
        }

        public void start_Destroy()
        {
            StartCoroutine(WaitToDestroy());
        }
    }
}