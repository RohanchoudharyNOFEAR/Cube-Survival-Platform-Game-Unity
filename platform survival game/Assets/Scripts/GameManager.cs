using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  
    public int Timer=100;
    public bool IsObjectiveCompleted = false;
    private Health _health;
    public static GameManager GMInstance;

    private void Awake()
    {
        if(GMInstance==null)
        {
            GMInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else { Destroy(gameObject); }
    }

    // Start is called before the first frame update
    void Start()
    {
        _health = GameObject.FindObjectOfType<Health>().GetComponent<Health>();
        StartCoroutine(StartCountDown());
    }

    // Update is called once per frame
    void Update()
    {
        RestartLevel();
        NextLevelloader();
    }

   public void RestartLevel()
    {
        if(_health.IsplayerDead())
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }


    public void NextLevelloader()
    {
        if(IsObjectiveCompleted==true)
        {
            int nextscene = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextscene);
        }
    }

    //if mission objective is countdowntimer
    IEnumerator StartCountDown()
    {
        yield return new WaitForSeconds(1f);
        Timer--;
        
        if (Timer == 0)
        {
            RestartLevel();
        }
       // _counterText.text = "TimeLeft :" + CountDown;
        StartCoroutine(StartCountDown());
    }

}
