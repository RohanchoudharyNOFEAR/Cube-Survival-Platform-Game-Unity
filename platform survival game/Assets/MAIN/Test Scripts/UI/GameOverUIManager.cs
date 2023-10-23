using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;
using UnityEngine.SceneManagement;

namespace TestOnly
{
    public class GameOverUIManager : NetworkBehaviour
    {
        public static GameOverUIManager instance;

        [SerializeField]
        private GameObject GameOverPanel;
        [SerializeField]
        private GameObject ExitToMainMenuButton;
        [SerializeField]
        private GameObject ExitToMainMenuButtonWinner;

        [SerializeField]
        private GameObject WinnerPanel;
        [SerializeField]
        private PlayerManager playerManager;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        //   private readonly ulong[] targetClientsArray = new ulong[1];

        //   private PlayerManager[] players;

        // Start is called before the first frame update
        void Start()
        {
            playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
            // DontDestroyOnLoad(gameObject);
            //  players = GameObject.FindObjectsOfType<PlayerManager>();
        }

        

        // Update is called once per frame
        void Update()
        {

        }



        public void SetActiveGameOverPanel(NetworkManager networkManager)
        {
            GameOverPanel.SetActive(true);
            if (networkManager.IsHost)
            {
                StartCoroutine(CheckForGameFinished());
                // ExitToMainMenuButton.SetActive(true);
            }
        }

        public void SetActiveFalseGameOverPanel()
        {
            GameOverPanel.SetActive(false);
        }

        public void ResetGameToMainMenu()
        {
          
            //NetworkManager.Singleton.SceneManager.LoadScene("Main Menu 1", LoadSceneMode.Single);
            //  NetworkManager.Singleton.Shutdown();
            //  DisconnectClientRpc();

            for (int i = 0; i < NetworkManager.Singleton.ConnectedClientsList.Count; i++)
            {
                ulong id = NetworkManager.Singleton.ConnectedClientsList[i].ClientId;
                 SendMessageServerRpc(id);
               // playerManager.SendMessageServerRpc(id);
            }
                
            DisconnectServerRpc();
           
          //  SceneManager.LoadScene("Main Menu 1");
        }

        [ServerRpc]
        private void DisconnectServerRpc()
        {
            DisconnectClientRpc();
        }

        [ClientRpc]
        private  void DisconnectClientRpc(ClientRpcParams clientRpcParams = default)
        {
            
            GameObject.Destroy(WorldGameManager.Instance.gameObject);
            GameObject.Destroy(LevelManager.instance.gameObject);
            GameObject.Destroy(AudioManager.Instance.gameObject);
            NetworkObject winnerPlayerInstance = NetworkManager.Singleton.LocalClient.PlayerObject;
            PlayerManager player = winnerPlayerInstance.gameObject.GetComponent<PlayerManager>();
            Destroy(player.playerCamera.gameObject);
            GameObject.Destroy(PlayerUIManager.instance.gameObject);
            //GameObject.Destroy(HostManager.Instance.gameObject);
            //GameObject.Destroy(ClientManager.Instance.gameObject);
            //  NetworkManager.Singleton.Shutdown();

            // NetworkManager.Singleton.SceneManager.LoadScene("Main Menu 1", LoadSceneMode.Single);
            // var async = SceneManager.LoadSceneAsync("Main Menu 1", LoadSceneMode.Single);

            //  NetworkManager.Singleton.Shutdown();
            //  NetworkManager networkManager = GameObject.FindObjectOfType<NetworkManager>();

            // GameObject.Destroy(networkManager.gameObject);



            if (NetworkManager.Singleton.IsHost)
            {
                for (int i = 0; i < NetworkManager.Singleton.ConnectedClientsList.Count; i++)
                {
                    ulong id = NetworkManager.Singleton.ConnectedClientsList[i].ClientId;

                    if (NetworkManager.Singleton.LocalClientId == id) continue;

                 //   DespawnPlayerServerRpc(id);

                    NetworkManager.Singleton.DisconnectClient(id);
                }

                // DespawnPlayerServerRpc(NetworkManager.Singleton.LocalClientId);
               
                NetworkManager.Singleton.Shutdown();
                Destroy(NetworkManager.Singleton.gameObject);
               
                Debug.Log("is host scene called");
                SceneManager.LoadScene("Main Menu 1", LoadSceneMode.Single);
            }
            else
            {
               // DespawnPlayerServerRpc(NetworkManager.Singleton.LocalClientId);

                Cursor.lockState = CursorLockMode.None;

                NetworkManager.Singleton.Shutdown();
                Destroy(NetworkManager.Singleton.gameObject);
                Debug.Log("is client scene called");
                SceneManager.LoadScene("Main Menu 1", LoadSceneMode.Single);
            }

        }
        [ServerRpc]
        private void SendMessageServerRpc(ulong id)
        {
            SendMessageToClientRpc(id);
        }

        [ClientRpc]
        private void SendMessageToClientRpc(ulong id)
        {
            Debug.Log("Hello Clients");
        }

        IEnumerator CheckForGameFinished()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.3f);

                if (WorldGameManager.Instance.GameFinished == true)
                {
                    ExitToMainMenuButton.SetActive(true);
                    StopCoroutine(CheckForGameFinished());
                }
            }

        }

        public void DisplayWinnerPanel()
        {
            WinnerPanel.SetActive(true);
            if (WorldGameManager.Instance.GameFinished == true)
            {
                if (NetworkManager.Singleton.IsHost)
                {
                    ExitToMainMenuButtonWinner.SetActive(true);
                }


            }

        }



    }
}