using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Objective
{
    Timer,
    Collect
}

public class GameManager : MonoBehaviour
{
    public static GameManager GMInstance;
    public Objective Objectives;

    public int Timer=100;
    public bool IsObjectiveCompleted = false;
    private Health _health;
   
    private bool _isTimeUp;
    private bool _collectionTargetReached=false;
    [SerializeField]
    private  int _collectedItems=0;
    public int CollectedItems { get { return _collectedItems; } set { _collectedItems = value; } }
    [SerializeField]
    private int _noItemTocollect;
    public int NoItemToCollecte { get { return _noItemTocollect; } set { _noItemTocollect = value; } }


    private void Awake()
    {
        if(GMInstance==null)
        {
            GMInstance = this;
           // DontDestroyOnLoad(this.gameObject);
        }
       // else { Destroy(gameObject); }
    }

    private void OnDisable()
    {
        GMInstance = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        _collectedItems = 0;
        _collectionTargetReached = false;
        _health = GameObject.FindObjectOfType<Health>().GetComponent<Health>();      
            StartCoroutine(StartCountDown());                      
    }

    // Update is called once per frame
    void Update()
    {
        CheckForObjectiveCompletion();
        CountCollectable();
       // RestartLevel();
        //NextLevelloader();
    }

   public void RestartLevel()
    {
        if(_health!=null)
        {
            if (_health.IsplayerDead())
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            }
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
            //  RestartLevel();
            _isTimeUp = true;
        }
       // _counterText.text = "TimeLeft :" + CountDown;
        StartCoroutine(StartCountDown());
    }

    private void CountCollectable()
    {
        if(CollectedItems>=NoItemToCollecte)
        {
            _collectionTargetReached = true;
        }
    }

    public void CheckForObjectiveCompletion()
    {
        if(Objectives == Objective.Timer)
        {
            if(_isTimeUp==true&&_health.IsplayerDead()==false&& IsObjectiveCompleted==false)
            {
               IsObjectiveCompleted = true;
                StopCoroutine(StartCountDown());
                NextLevelloader();
               
                IsObjectiveCompleted = false;
            }
            else if(_isTimeUp==false && _health.IsplayerDead()==true)
            {
                RestartLevel();
            }
           
        }
        else if(Objectives == Objective.Collect)
        {
            if(_collectionTargetReached==true && _isTimeUp==false && _health.IsplayerDead()==false&&IsObjectiveCompleted==false)
            {
                Debug.Log("level2");
               IsObjectiveCompleted = true;
                StopCoroutine(StartCountDown());
                NextLevelloader();
                IsObjectiveCompleted = false;
            }
            else if (_isTimeUp == false && _health.IsplayerDead() == true)
            {
                RestartLevel();
            }
        }
    }

}
