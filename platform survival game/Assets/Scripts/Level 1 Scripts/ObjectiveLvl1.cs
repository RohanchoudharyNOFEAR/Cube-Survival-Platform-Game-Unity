using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveLvl1 : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
   [SerializeField] private float TimeLeft;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        TimeLeft = _gameManager.Timer;
    }

    // Update is called once per frame
    void Update()
    {
        Objective();
    }

     void Objective()
    {
        TimeLeft -= Time.deltaTime;
        if(TimeLeft<0 && _gameManager.IsObjectiveCompleted==false)
        {
            _gameManager.IsObjectiveCompleted = true;
        }
    }
}
