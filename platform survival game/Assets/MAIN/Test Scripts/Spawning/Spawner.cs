using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace TestOnly
{
    public class Spawner : NetworkBehaviour 
    {
        public float interval = 1f;
        [Header("Abilities/ Colleactables")]
        public GameObject[] spawnablesItems;
        [SerializeField]
        public float _maxX, _minX;
        [SerializeField]
        public float _minZ, _maxZ;
        [SerializeField]
        public float _maxY;

        // Start is called before the first frame update
        protected virtual void Start()
        {

        }

        // Update is called once per frame
        protected virtual void Update()
        {

        }

        public virtual void Spawn()
        {
            int RandomSelction = Random.Range(0, spawnablesItems.Length);
            Vector3 spawnPosition = new Vector3(Random.Range(_minX, _maxX), _maxY, Random.Range(_minZ, _maxZ));

            if (RandomSelction == 0)
            {
                NetworkObject obj = NetworkObjectPool.Singleton.GetNetworkObject(spawnablesItems[0], spawnPosition, Quaternion.identity);
                if (!obj.IsSpawned)
                {
                    obj.GetComponent<Collectable>().prefab = spawnablesItems[0];

                    obj.Spawn(true);
                    //obj.GetComponent<Collectable>().DestroyGameobject();
                    // enemy.GetComponent<EnemyParentForwardMovement02>().start_Destroy();
                }
            }


        }

       public virtual IEnumerator startspawn()
        {
            yield return new WaitForSeconds(3f);
            while (true)
            {
                Spawn();
                yield return new WaitForSeconds(interval);
            }
        }

        public void Start_coroutine()
        {
            StartCoroutine("startspawn");
        }

        private void Stop_coroutine()
        {
            StopCoroutine("startspawn");
        }

    }
}