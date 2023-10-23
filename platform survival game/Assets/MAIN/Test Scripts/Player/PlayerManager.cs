using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

namespace TestOnly
{
    public class PlayerManager : NetworkBehaviour
    {
        public PlayerNetworkManager playerNetworkManager;
        public PlayerLocomotionManager playerLocomotionManager;
        // public PlayerUIManager playerUIManager;
        public PlayerInputs playerInputs;
        public PlayerCamera playerCamera;

        [Header("Player networking")]
        private readonly ulong[] targetClientsArray = new ulong[1];

        //[Header("UI")]
        //[SerializeField] private GameOverUIManager gameOverUIManager;

        [Header("Joystick")]
       [SerializeField] private Joystick Joystick;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
            playerNetworkManager = GetComponent<PlayerNetworkManager>();
            // playerUIManager = GetComponent<PlayerUIManager>();
            playerCamera = GameObject.Find("Main Camera").GetComponent<PlayerCamera>();
            playerInputs = GetComponent<PlayerInputs>();
            //  gameOverUIManager = GameObject.Find("Player Game Over Canvas").GetComponent<GameOverUIManager>();
            //error

        }
        private void OnEnable()
        {
            Collectable.OnCollectableRewardItemCollodeAction += IncrementScoreClientRpc;
            EnemyDealDamage.OnCollidedEnemyEvent += DealDamageClientRpc;
            WorldGameManager.OnGameFinishedAction += DisableJoyStickClientRpc;
        }
        private void OnDisable()
        {
            EnemyDealDamage.OnCollidedEnemyEvent -= DealDamageClientRpc;
            Collectable.OnCollectableRewardItemCollodeAction -= IncrementScoreClientRpc;
            WorldGameManager.OnGameFinishedAction -= DisableJoyStickClientRpc;
        }

        public override void OnNetworkSpawn()
        {
            base.OnNetworkSpawn();

            // playerCamera.cameraFollow.player = gameObject.transform;
            playerNetworkManager.currentLives.OnValueChanged += checkLives;
            //if (IsOwner)
            //{
            //    gameOverUIManager = GameObject.Find("Player Game Over Canvas").GetComponent<GameOverUIManager>();
            //}
        }

        private void Start()
        {
            if (IsOwner)
            {
                ulong id = GetComponent<NetworkObject>().OwnerClientId;
                targetClientsArray[0] = id;
                ClientRpcParams clientRpcParams = new ClientRpcParams
                {
                    Send = new ClientRpcSendParams { TargetClientIds = targetClientsArray }
                };

                // InitilizeCameraClientRpc();

                playerCamera.cameraFollow.Initilize(transform);
                InitilizeJoyStickClientRpc(clientRpcParams);
                //    InitilizeGameOverUIManagerClientRpc(clientRpcParams);
                //Joystick = GameObject.Find("Floating Joystick").GetComponent<FloatingJoystick>();
                //playerInputs.Joystick = this.Joystick;
            }
            SceneManager.activeSceneChanged += getJoystick;
        }

        [ClientRpc]
        public void InitilizeJoyStickClientRpc(ClientRpcParams clientRpcParams = default)
        {
            if (IsOwner)
            {
                Joystick = GameObject.Find("Floating Joystick").GetComponent<FloatingJoystick>();
                playerInputs.Joystick = this.Joystick;
            }
        }

        [ClientRpc]
        public void DisableJoyStickClientRpc(ClientRpcParams clientRpcParams = default)
        {
            if (IsOwner)
            {
                if (Joystick != null)
                {
                  playerInputs.Joystick.gameObject.SetActive(false);
                }
            }
        }
        public void getJoystick(Scene current, Scene next)
        {
            if (GameObject.Find("Floating Joystick") != null)
            {
                Debug.Log("getjoystick called");
                Joystick = GameObject.Find("Floating Joystick").GetComponent<FloatingJoystick>();
                playerInputs.Joystick = Joystick;
            }
            // Joystick = GameObject.Find("Floating Joystick").GetComponent<FloatingJoystick>();

        }

        //[ClientRpc]
        //public void InitilizeGameOverUIManagerClientRpc(ClientRpcParams clientRpcParams = default)
        //{
        //    if (IsOwner)
        //    {
        //        gameOverUIManager = GameObject.Find("Player Game Over Canvas").GetComponent<GameOverUIManager>();

        //    }
        //}


        private void Update()
        {

            if (IsOwner)
            {
                playerNetworkManager.networkPosition.Value = transform.position;
                playerNetworkManager.networkRotation.Value = transform.rotation;

            }
            else
            {
                transform.position = Vector3.SmoothDamp(transform.position, playerNetworkManager.networkPosition.Value, ref playerNetworkManager.networkPositionVelocity, playerNetworkManager.networkPositionSmoothTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, playerNetworkManager.networkRotation.Value, playerNetworkManager.networkRotationSmoothTime);
            }

            if (!IsOwner)
            {
                return;

            }
            playerLocomotionManager.Move();
            PlayerOutOfBound();
            // playerNetworkManager.currentLives.OnValueChanged += checkLives;

        }

        private void PlayerOutOfBound()
        {
           
            if (IsOwner)
            {
                if (playerNetworkManager.isDead.Value == false)
                {
                    if (transform.position.y < -2f)
                    {

                        DealDamageServerRpc(3);
                       // DealDamageClientRpc(3, clientRpcParams);
                        Debug.Log("dead");
                    }
                }
            }
        }


        //makes client player is dead variable true
        [ClientRpc]
        private void PlayerDiedClientRpc(ClientRpcParams clientRpcParams = default)
        {
            if (IsOwner)
            {
                playerNetworkManager.isDead.Value = true;
            }
        }

        public void checkLives(int oldvalues, int newvalues)
        {
            ulong id = OwnerClientId;
            targetClientsArray[0] = id;
            ClientRpcParams clientRpcParams = new ClientRpcParams
            {
                Send = new ClientRpcSendParams { TargetClientIds = targetClientsArray }
            };


            if (playerNetworkManager.currentLives.Value <= 0)
            {
                PlayerDiedClientRpc(clientRpcParams);

                if (IsOwner)
                {
                    // gameOverUIManager.SetActiveGameOverPanel(this.NetworkManager);
                    GameOverUIManager.instance.SetActiveGameOverPanel(this.NetworkManager);
                }


                //if (IsOwner&&IsClient &&!IsHost)
                //{
                //    Debug.Log("Player Disconnected");
                //    //ChangePlayerSceneToMainMenuClientRpc(clientRpcParams);
                //   // NetworkManager.Singleton.Shutdown();
                //}
                // dead
            }
            // PREVENTS US FROM OVER HEALING
            if (this.IsOwner)
            {
                if (playerNetworkManager.currentLives.Value > playerNetworkManager.totalLives.Value)
                {
                    playerNetworkManager.currentLives.Value = playerNetworkManager.totalLives.Value;
                }
            }
            //current lives-3
            //isdead false
        }



        [ClientRpc]
        public void IncrementScoreClientRpc(ClientRpcParams clientRpcParams = default)
        {
            if (!IsOwner)
            {
                return;

            }
            playerNetworkManager.score.Value++;
            PlayerUIManager.instance.DisplayCollectedItems(playerNetworkManager);
        }



        public void IncreaseHealth()
        {
            if (!IsOwner) { return; }

            if (playerNetworkManager.isDead.Value == false && playerNetworkManager.currentLives.Value < playerNetworkManager.totalLives.Value)
            {
                playerNetworkManager.currentLives.Value++;
                PlayerUIManager.instance._increasePlayerHealthUI();
                //if (OnHealthIncreaseEvent != null)
                //{
                //    OnHealthIncreaseEvent();
                //}
            }

        }

        public void DecreaseHealth(int DecreaseHeathAmount = 1)
        {
            if (!IsOwner) { return; }
            if (playerNetworkManager.isDead.Value == false)
            {
                playerNetworkManager.currentLives.Value -= DecreaseHeathAmount;
                PlayerUIManager.instance._decreasePlayerHealthUI();
                //if (OnHealthDecreaseEvent != null)
                //{
                //    OnHealthDecreaseEvent();
                //}

            }

        }
        [ServerRpc]
        private void DealDamageServerRpc(int DecreaseHealthAmount = 1)
        {
            ulong id = OwnerClientId;
            targetClientsArray[0] = id;
            ClientRpcParams clientRpcParams = new ClientRpcParams
            {
                Send = new ClientRpcSendParams { TargetClientIds = targetClientsArray }
            };
            DealDamageClientRpc(DecreaseHealthAmount, clientRpcParams);
        }

        [ClientRpc]
        private void DealDamageClientRpc(  int DecreaseHealthAmount = 1, ClientRpcParams clientRpcParams = default)
        {
            Debug.Log("deal damage called");
            if (!IsOwner) { return; }
            Debug.Log("deal damage called");
            //play hurt Effect
            //  PlayerEffects.Instance.HurtEffect();
            AudioManager.Instance.playHurtAudio();
            //health--
            DecreaseHealth(DecreaseHealthAmount);
            Vibration.Vibrate(500);
            playerCamera.StartShakeCoroutine();
            //bounce off effect
            // PlayerEffects.Instance.BounceBackEffect(other);
        }

        [ClientRpc]
        public void ChangePlayerSceneToMainMenuClientRpc(ClientRpcParams clientRpcParams = default)
        {
            if (!IsOwner)
            {
                return;
            }

            SceneManager.LoadScene("Main Menu 1");
            //  NetworkManager.Singleton.SceneManager.LoadScene("Main Menu 1", LoadSceneMode.Single);

        }

        //test only
        #region test
        [ServerRpc(RequireOwnership =false)]
        public void SendMessageServerRpc(ulong id)
        {
            SendMessageToClientRpc(id);
        }

        [ClientRpc]
        private void SendMessageToClientRpc(ulong id)
        {
            Debug.Log("Hello Clients");
        }
        #endregion


    }
}