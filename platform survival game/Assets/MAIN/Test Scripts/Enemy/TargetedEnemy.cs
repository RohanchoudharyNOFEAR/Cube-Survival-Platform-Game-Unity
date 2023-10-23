using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace TestOnly
{
    public class TargetedEnemy : NetworkBehaviour
    {
        [Header("Network Prefab")]
        public GameObject prefab;

        [SerializeField]
        private float speed;

        [SerializeField]
        private int damage;
        [SerializeField]
        private float ExplosionRadius = 10f;
        [SerializeField]
        private float ExplosionStrength = 5f;
        [SerializeField]
        private ParticleSystem ExplosionParticle;

        // [SerializeField]
        // private EnemyDataSO data;
        //  [SerializeField]
        //  private TargetedEnemyDataSO data;


      [SerializeField]  private GameObject[] Players;
      [SerializeField]  private GameObject targetPlayer;
        public GameObject parent;

        private void Awake()
        {
          //  Player = GameObject.FindGameObjectWithTag("Player");
            //parent = transform.parent.gameObject;
        }

        private void OnEnable()
        {
           // Invoke("DestroyGameobject", 6f);
        }
        // Start is called before the first frame update
        void Start()
        {
            float minDistance = 0;
             Players = GameObject.FindGameObjectsWithTag("Player");
            foreach(GameObject player in Players)
            {
                if(minDistance< Vector3.Distance(transform.position,player.transform.position))
                {
                    minDistance = Vector3.Distance(transform.position, player.transform.position);
                    targetPlayer = player;
                }
            }
            parent = transform.parent.gameObject;
            //  Invoke("DestroyGameobject", 6f);
        }


        // Update is called once per frame
        void Update()
        {
            Followplayer();
            //  DestroyGameobject();
            //Debug.Log("particle isplaying" + ExplosionParticle.isPlaying);
            //Debug.Log("particle isemitting" + ExplosionParticle.isEmitting);
            //Debug.Log("particle is stopped" + ExplosionParticle.isStopped);
            //Debug.Log("particle isalive" + ExplosionParticle.IsAlive());
        }

        void Followplayer()
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPlayer.transform.position, speed * Time.deltaTime);
        }
        private  void DestroyGameobject()
        {
             PlayExplosionParticle();
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.TargetedEnemeyExplosionAudio();
            }
            ExplosionEffect();

            StartCoroutine(WaitToCallDestroyParent());
          //  Invoke("parent.GetComponent<TargetEnemyParent>().DestroyGameobject()",0.56f);
                Debug.Log("destroting parent");
            
            //if (NetworkObjectPool.Singleton != null)
            //{
            //    parent.GetComponent<NetworkObject>().gameObject.SetActive(false);
            //    //NetworkObjectPool.Singleton.ReturnNetworkObject(parent.GetComponent<NetworkObject>(), prefab);
            //    NetworkObjectPool.Singleton.ReturnNetworkObject(NetworkObject, prefab);
            //    if (parent.GetComponent<NetworkObject>().IsSpawned)
            //    {
            //        //  NetworkObjectPool.Singleton.ReturnNetworkObject(NetworkObject, prefab);
                    
            //       // parent.GetComponent<NetworkObject>().Despawn();
            //        NetworkObject.Despawn();
            //    }
            //}
            //else
            //{

            //    Destroy(parent, 0.1f);
            //}

        }

        IEnumerator WaitToCallDestroyParent()
        {
            yield return new WaitForSeconds(0.25f);
            parent.GetComponent<TargetEnemyParent>().DestroyGameobject();
        }

        private void ExplosionEffect()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, ExplosionRadius);
            foreach (Collider item in colliders)
            {
                Rigidbody rb = item.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(ExplosionStrength, transform.position, ExplosionRadius, 0, ForceMode.Impulse);
                }
            }
        }

        private  void PlayExplosionParticle()
        {
          
            ExplosionParticle.Play();
          
        }


        IEnumerator WaitToDestroy()
        {
            yield return new WaitForSeconds(6);
            DestroyGameobject();
            yield return null;
        }

        public void start_Destroy()
        {
            StartCoroutine(WaitToDestroy());
        }

    }
}