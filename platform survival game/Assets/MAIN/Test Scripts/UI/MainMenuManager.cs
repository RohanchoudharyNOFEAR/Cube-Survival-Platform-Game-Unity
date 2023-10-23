using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.Services.Core;
using Unity.Services.Authentication;
using System;

namespace TestOnly
{
    public class MainMenuManager : MonoBehaviour
    {

        [Header("References")]
        [SerializeField] private GameObject connectingPanel;
        [SerializeField] private GameObject menuPanel;
        [SerializeField] private TMP_InputField joinCodeInputField;

        private async void Start()
        {
           // menuPanel.SetActive(true);
            try
            {
                await UnityServices.InitializeAsync();
                if (!AuthenticationService.Instance.IsSignedIn)
                {
                    await AuthenticationService.Instance.SignInAnonymouslyAsync();
                    Debug.Log($"Player Id: {AuthenticationService.Instance.PlayerId}");
                }
            }
            catch (Exception e)
            {
                Debug.Log(e);
                return;
            }

            connectingPanel.SetActive(false);
            menuPanel.SetActive(true);
        }

     

        public async void StartHost()
        {
           
            HostManager.Instance.StartHost();
            // await HostSingleton.Instance.StartHostAsync();
        }

        public async void StartClient()
        {
            ClientManager.Instance.StartClient(joinCodeInputField.text);
          //  NetworkManager.Singleton.StartClient();
           // await ClientSingleton.Instance.Manager.BeginConnection(joinCodeInputField.text);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

    }
}
