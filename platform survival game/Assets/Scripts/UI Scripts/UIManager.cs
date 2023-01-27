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
    private Health Health;

    // Start is called before the first frame update
    void Start()
    {
        Health = GameObject.FindObjectOfType<Health>().GetComponent<Health>();
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>() ?? null ;
        CountDown = _gameManager.Timer;
        _counterText = GameObject.Find("Timer Text").GetComponent<TMP_Text>();

      //  StartCoroutine(StartCountDown());
    }

    // Update is called once per frame
    void Update()
    {
        DisplayLives();
        DisplayTimer();
    }

    void DisplayLives()
    {
        if (Health != null)
        {
            _livesImageDisplay.sprite = _lives[Health._Health];
        }
            
    }


    private void DisplayTimer()
    {
        if(_gameManager!=null)
        {
            _counterText.text = "TimeLeft :" + _gameManager.Timer;
        }
        
    }


    /*
    IEnumerator StartCountDown()
    {
        yield return new WaitForSeconds(1f);
        CountDown--;
        if(CountDown==0)
        {
            _gameManager.RestartLevel();
        }
        _counterText.text = "TimeLeft :" + CountDown;
        StartCoroutine(StartCountDown());
    }
    */

}
