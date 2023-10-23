using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System;

namespace TestOnly
{
    //genral script for items that are coolectable or triggered such as ability and reward items
    public class Collectable : NetworkBehaviour
    {
        public GameObject prefab;
        // private PlayerManager playerManager;
        public delegate void CollectableCollideAction(ClientRpcParams clientRpcParams);
        public static CollectableCollideAction OnCollectableRewardItemCollodeAction;
        public static CollectableCollideAction OnCollectableAbilityCollodeAction;


        private readonly ulong[] targetClientsArray = new ulong[1];

        private void Awake()
        {
            // playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                CollidedWithPlayer(other);
                DestroyGameObject();
            }
        }

        protected virtual void CollidedWithPlayer(Collider other)
        {
            Debug.Log("CollidedWithPlayer");
            
            ulong id = other.GetComponent<NetworkObject>().OwnerClientId;
            targetClientsArray[0] = id;
            ClientRpcParams clientRpcParams = new ClientRpcParams
            {
                Send = new ClientRpcSendParams { TargetClientIds = targetClientsArray }
            };

            CheckTypeOfCollectable(clientRpcParams);
            DestroyGameObject();
           
        }

        //check if collectable is ability or collectable item using tags
        private void CheckTypeOfCollectable(ClientRpcParams clientRpcParams)
        {
            if (gameObject.CompareTag("RewardItem"))
            {
                if (OnCollectableRewardItemCollodeAction != null)
                {
                    OnCollectableRewardItemCollodeAction(clientRpcParams);
                    AudioManager.Instance.CollectableItemCollectedSound();
                }
            }
            else if(gameObject.CompareTag("Ability"))
            {
                if (OnCollectableAbilityCollodeAction != null)
                {
                  
                    OnCollectableAbilityCollodeAction(clientRpcParams);
                    AudioManager.Instance.CollectableItemCollectedSound();
                }
            }
        }

        private void DestroyGameObject()
        {
            if (NetworkObjectPool.Singleton != null)
            {
                //  prefab.SetActive(false);
                NetworkObject.gameObject.SetActive(false);
                try
                {
                    NetworkObjectPool.Singleton.ReturnNetworkObject(NetworkObject, prefab);

                    if (NetworkObject.IsSpawned)
                    {
                        NetworkObject.Despawn(false);
                    }
                }
                catch(Exception e)
                {
                    Debug.Log(e);
                }
            }
        }

    }
}