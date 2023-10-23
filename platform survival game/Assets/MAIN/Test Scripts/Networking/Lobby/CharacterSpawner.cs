using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace TestOnly
{
    public class CharacterSpawner : NetworkBehaviour
    {
        [Header("References")]
        [SerializeField] private CharacterDatabase characterDatabase;

      

        private void Awake()
        {
          
        }

        public override void OnNetworkSpawn()
        {
            if (!IsServer) { return; }
           
            if (HostManager.Instance.isPlayerSpawned == false)
            {
                HostManager.Instance.isPlayerSpawned = true;
                foreach (var client in HostManager.Instance.ClientData)
                {
                    var character = characterDatabase.GetCharacterById(client.Value.characterId);
                    if (character != null)
                    {
                        var spawnPos = new Vector3(Random.Range(-3f, 3f), 1f, Random.Range(-3f, 3f));

                        var characterInstance = Instantiate(character.GameplayPrefab, spawnPos, Quaternion.identity);
                        characterInstance.GetComponent<NetworkObject>().SpawnAsPlayerObject(client.Value.clientId);
                        Debug.Log("character" + client.Value.clientId);
                        //characterInstance.SpawnAsPlayerObject(client.Value.clientId);
                    }
                }
            }
        }
    }
}