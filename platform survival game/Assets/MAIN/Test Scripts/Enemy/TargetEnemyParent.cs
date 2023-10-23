using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace TestOnly
{
    public class TargetEnemyParent : Enemy
    {
        [Header("Network Prefab")]
        public GameObject prefab;

        // Start is called before the first frame update
        void Start()
        {

        }

        public void DestroyGameobject()
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
    }
}