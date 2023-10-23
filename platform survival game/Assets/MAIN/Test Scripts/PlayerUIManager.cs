using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;

namespace TestOnly
{
    public class PlayerUIManager : MonoBehaviour
    {
        public static PlayerUIManager instance;

        [SerializeField]
        private Sprite[] _lives;
        [SerializeField]
        private Image _livesImageDisplay;
       // public int CountDown;
        //[SerializeField]
        //private TMP_Text _counterText;

      //  [SerializeField]
       // private PlayerManager _playerManager = null;

        [SerializeField]
        private TMP_Text scoreText;

        private int _playerHealthUI = 3;

        private void Awake()
        {
            if(instance==null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            DontDestroyOnLoad(this);

            //_playerManager =  GetComponent<PlayerManager>() ?? null;
            // CountDown = _gameManager.Timer;
            //_counterText = GameObject.Find("Timer Text").GetComponent<TMP_Text>();
            scoreText = GameObject.Find("Collected Items Text").GetComponent<TMP_Text>() ?? null;
            //  StartCoroutine(StartCountDown());
        }

        private void OnEnable()
        {
           

            //Health.OnHealthDecreaseEvent += _decreasePlayerHealthUI;
            //Health.OnHealthIncreaseEvent += _increasePlayerHealthUI;
        }

        private void OnDisable()
        {
          

            //Health.OnHealthDecreaseEvent -= _decreasePlayerHealthUI;
            //Health.OnHealthIncreaseEvent -= _increasePlayerHealthUI;
        }

        // Update is called once per frame
        void Update()
        {
            DisplayLives();
           // DisplayCollectedItems();
        }

        void DisplayLives()
        {
            if (_playerHealthUI >= 0)
            {
                _livesImageDisplay.sprite = _lives[_playerHealthUI];
            }
        }


        //private void DisplayTimer()
        //{
        //    if (_gameManager != null)
        //    {
        //        _counterText.text = "TimeLeft :" + _gameManager.Timer;
        //    }

        //}

       
        public void _increasePlayerHealthUI()
        {          
            _playerHealthUI++;
        }

      
        public void _decreasePlayerHealthUI()
        {
            _playerHealthUI--;
        }


       public void DisplayCollectedItems(PlayerNetworkManager playerNetworkManager)
        {
            if (scoreText != null)
            {
                scoreText.text = "Score : " + playerNetworkManager.score.Value ;
            }
        }


    }
}