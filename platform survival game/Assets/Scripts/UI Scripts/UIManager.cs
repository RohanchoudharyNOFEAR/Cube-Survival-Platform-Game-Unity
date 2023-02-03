using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _lives;
    [SerializeField]
    private Image _livesImageDisplay;
    public int CountDown;
    [SerializeField]
    private TMP_Text _counterText;
    [SerializeField]
    private GameManager _gameManager=null;
    [SerializeField]
    private TMP_Text _CollectedItemsText;
   
    private int _playerHealthUI = 3;

    // Start is called before the first frame update
    void Start()
    {
      
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>() ?? null ;
        CountDown = _gameManager.Timer;
        _counterText = GameObject.Find("Timer Text").GetComponent<TMP_Text>();
        _CollectedItemsText = GameObject.Find("Collected Items Text").GetComponent<TMP_Text>()??null;
      //  StartCoroutine(StartCountDown());
    }

    private void OnEnable()
    {
        Health.OnHealthDecreaseEvent += _decreasePlayerHealthUI;
        Health.OnHealthIncreaseEvent += _increasePlayerHealthUI;
    }

    private void OnDisable()
    {
        Health.OnHealthDecreaseEvent -= _decreasePlayerHealthUI;
        Health.OnHealthIncreaseEvent -= _increasePlayerHealthUI;
    }

    // Update is called once per frame
    void Update()
    {
        DisplayLives();
        DisplayTimer();
        DisplayCollectedItems();
    }

    void DisplayLives()
    {        
            _livesImageDisplay.sprite = _lives[_playerHealthUI];                        
    }


    private void DisplayTimer()
    {
        if(_gameManager!=null)
        {
            _counterText.text = "TimeLeft :" + _gameManager.Timer;
        }
        
    }

    private void _increasePlayerHealthUI()
    {
        _playerHealthUI++;
    }
    private void _decreasePlayerHealthUI()
    {
        _playerHealthUI--;
    }

    void DisplayCollectedItems()
    {
        if(_CollectedItemsText!=null)
        {
            _CollectedItemsText.text = "Items:" + _gameManager.CollectedItems + "/" + _gameManager.NoItemToCollecte;
        }   
    }
  

}
