using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace TestOnly
{
    public class EnemyDealDamage : MonoBehaviour
    {
       
        public delegate void EnemyCollideAction(  int DecreaseHealthAmount = 1, ClientRpcParams clientRpcParams = default);
        public static event EnemyCollideAction OnCollidedEnemyEvent;
        public static event EnemyCollideAction OnEnemeyColliderExitEvent;

        private readonly ulong[] targetClientsArray = new ulong[1];

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                ulong id = collision.gameObject.GetComponent<NetworkObject>().OwnerClientId;
                targetClientsArray[0] = id;
                ClientRpcParams clientRpcParams = new ClientRpcParams
                {
                    Send = new ClientRpcSendParams { TargetClientIds = targetClientsArray }
                };

                Debug.Log("collision detected");
                if (OnCollidedEnemyEvent != null)//very important
                {
                    OnCollidedEnemyEvent(/*collision,*/1, clientRpcParams);

                }
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                ulong id = collision.gameObject.GetComponent<NetworkObject>().OwnerClientId;
                targetClientsArray[0] = id;
                ClientRpcParams clientRpcParams = new ClientRpcParams
                {
                    Send = new ClientRpcSendParams { TargetClientIds = targetClientsArray }
                };

                Debug.Log("collision ended");
                if (OnEnemeyColliderExitEvent != null)//very important
                {
                    OnEnemeyColliderExitEvent(/*collision,*/1, clientRpcParams);
                }
            }
        }

    }
}