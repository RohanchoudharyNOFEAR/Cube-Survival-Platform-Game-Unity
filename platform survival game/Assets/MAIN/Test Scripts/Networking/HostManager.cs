using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using System;
using Unity.Networking.Transport.Relay;
using Unity.Netcode.Transports.UTP;

namespace TestOnly
{
    public class HostManager : MonoBehaviour
    {
        public static HostManager Instance
        {
            get; private set;
        }

        [Header("Settings")]
        [SerializeField] private int maxConnections = 4;
        [SerializeField] private string characterSelectSceneName = "CharacterSelect";

        //  private string gameplaySceneName = "Gameplay";
        public bool isPlayerSpawned = false;
        private bool gameHasStarted;

        public Dictionary<ulong, ClientData> ClientData { get; private set; }
        public string JoinCode { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
        public void StartServer()
        {
            ClientData = new Dictionary<ulong, ClientData>();
            NetworkManager.Singleton.ConnectionApprovalCallback += ApprovalCheck;
            NetworkManager.Singleton.OnServerStarted += OnNetworkReady;
            NetworkManager.Singleton.StartServer();
        }

        public async void StartHost()
        {
            Allocation allocation;
            try
            {
                allocation = await RelayService.Instance.CreateAllocationAsync(maxConnections);
            }
            catch (Exception e)
            {
                Debug.LogError($"Relay create allocation request failed {e.Message}");
                throw;
            }

            Debug.Log($"server: {allocation.ConnectionData[0]} {allocation.ConnectionData[1]}");
            Debug.Log($"server: {allocation.AllocationId}");

            try
            {
                JoinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);
            }
            catch
            {
                Debug.LogError("Relay create join code request failed");
                throw;
            }

            var relayServerData = new RelayServerData(allocation, "dtls");

            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);



            NetworkManager.Singleton.ConnectionApprovalCallback += ApprovalCheck;
            NetworkManager.Singleton.OnServerStarted += OnNetworkReady;
            ClientData = new Dictionary<ulong, ClientData>();
            NetworkManager.Singleton.StartHost();
        }

        private void ApprovalCheck(NetworkManager.ConnectionApprovalRequest request, NetworkManager.ConnectionApprovalResponse response)
        {
            if (ClientData.Count >= 4 || gameHasStarted)
            {
                response.Approved = false;
                return;
            }
            response.Approved = true;
            //response.CreatePlayerObject = false;
            response.Pending = false;
            ClientData[request.ClientNetworkId] = new ClientData(request.ClientNetworkId);
            Debug.Log($"Added client {request.ClientNetworkId}");
        }

        private void OnNetworkReady()
        {
            NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnect;
            NetworkManager.Singleton.SceneManager.LoadScene(characterSelectSceneName, LoadSceneMode.Single);
        }

        private void OnClientDisconnect(ulong clientId)
        {
            if (ClientData.ContainsKey(clientId))
            {
                if (ClientData.Remove(clientId))
                {
                    Debug.Log($"Removed client {clientId}");
                    // SceneManager.LoadScene(0);
                    //SceneManager.LoadScene("Main Menu 1");
                    //  NetworkManager.Singleton.SceneManager.LoadScene("Main Menu 1", LoadSceneMode.Single);
                    ChangeSceneServerRpc("Main Menu 1");
                }
            }
        }

      [ServerRpc(RequireOwnership =false)]
      private void ChangeSceneServerRpc(string MainMenu,ServerRpcParams serverRpcParams= default)
        {
            ChangeSceneClientRpc(MainMenu);
        }

        [ClientRpc]
        private void ChangeSceneClientRpc(string MainMenu, ClientRpcParams clientRpcParams = default)
        {
            if (!NetworkManager.Singleton.IsHost)
            {
                var async = SceneManager.LoadSceneAsync("Main Menu 1", LoadSceneMode.Single);
                SceneManager.LoadScene("Main Menu 1");
                Debug.Log("clientrpc called scene");
                NetworkManager.Singleton.SceneManager.LoadScene("Main Menu 1", LoadSceneMode.Single);
            }
        }

        public void StartGame()
        {
            gameHasStarted = true;
            LevelManager.instance.StartGameplay();
            // NetworkManager.Singleton.SceneManager.LoadScene(gameplaySceneName, LoadSceneMode.Single);
        }

        public void SetCharacter(ulong clientId, int characterId)
        {
            if (ClientData.TryGetValue(clientId, out ClientData data))
            {
                data.characterId = characterId;
            }
        }

    }
}