using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace TestOnly
{
    public class WorldGameManager : MonoBehaviour
    {
        public static WorldGameManager Instance
        {
            get; private set;
        }

        [SerializeField]
        public bool GameFinished { get; private set; }

        [SerializeField]
        private PlayerManager[] players;
        [SerializeField]
        private int DeadPlayers = 0;
        

        private FloatingJoyStickManager joyStickManager;

        private readonly ulong[] targetClientsArray = new ulong[1];
        public delegate void GameFinishedAction(ClientRpcParams clientRpcParams);
        public static GameFinishedAction OnGameFinishedAction;
      //  public static GameFinishedAction OnCollectableAbilityColAction;

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

        // Start is called before the first frame update
        void Start()
        {
            players = GameObject.FindObjectsOfType<PlayerManager>();

            GameObject.Find("Canvas").TryGetComponent<FloatingJoyStickManager>(out joyStickManager);
            StartCoroutine(CheckForActivePlayers());
            
        }



        // Update is called once per frame
        void Update()
        {
            if (GameFinished == false)
            {
                if (players.Length == 1)
                {
                    if (DeadPlayers == 1)
                    {
                        GameFinished = true;
                        Debug.Log("Game Finished");
                        StopCoroutine(CheckForActivePlayers());
                    }
                }
                else if (players.Length > 1)
                {
                    if (DeadPlayers >= players.Length - 1)
                    {

                        GameFinished = true;
                        Debug.Log("Game Finished");
                        StopCoroutine(CheckForActivePlayers());
                    }
                }
               
            }
                ResetAfterGameFinished();
            
        }
        bool gameeneded = false;
        private void ResetAfterGameFinished()
        {
           
            if (gameeneded==false)
            {
                if (GameFinished == true)
                {
                    gameeneded = true;


                    ulong id = NetworkManager.Singleton.LocalClient.ClientId;
                    targetClientsArray[0] = id;
                    ClientRpcParams clientRpcParams = new ClientRpcParams
                    {
                        Send = new ClientRpcSendParams { TargetClientIds = targetClientsArray }
                    };

                    Debug.Log("Game joystick deactivated");
                    //floating joystick off
                    OnGameFinishedAction(clientRpcParams);
                    CheckWhoIsWinner();
                    //  joyStickManager.DisableFloatingJoyStick();
                }
            }
        }

      

            //check for winner and display winner ui
            private void CheckWhoIsWinner()
        {
         // NetworkObject winnerPlayerInstance =  NetworkManager.Singleton.ConnectedClients[NetworkManager.Singleton.LocalClient.ClientId].PlayerObject;
            NetworkObject winnerPlayerInstance = NetworkManager.Singleton.LocalClient.PlayerObject;
           PlayerManager player= winnerPlayerInstance.gameObject.GetComponent<PlayerManager>();
            if(player.playerNetworkManager.isDead.Value == false)
            {
                GameOverUIManager.instance.DisplayWinnerPanel();
            }
        }

        IEnumerator CheckForActivePlayers()
        {
            while (true)
            {
              
                yield return new WaitForSeconds(0.3f);
                DeadPlayers = 0;
                // Debug.Log("check for active player called");
                foreach (PlayerManager player in players)
                {
                    if (player.playerNetworkManager.isDead.Value == true)
                    {
                        if (DeadPlayers <= 4)
                        {
                            DeadPlayers++;
                        }
                    }
                }
            }

        }

    }
}