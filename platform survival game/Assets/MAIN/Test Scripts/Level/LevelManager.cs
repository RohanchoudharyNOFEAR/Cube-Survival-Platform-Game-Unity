using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TestOnly
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager instance;

        public Level[] levels;
      [SerializeField]  int activeLevelIndex;
        public Level activeLevel;
        public PlayerManager playerManager;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }



        private void Start()
        {
            DontDestroyOnLoad(instance);



        }

        private void Update()
        {
            if (WorldGameManager.Instance != null)
            {
                if (WorldGameManager.Instance.GameFinished == true)
                {
                    StopCoroutine(StartLevels());
                }
            }
        }


        public void StartGameplay()
        {
            activeLevelIndex = 0;
            activeLevel = levels[activeLevelIndex];
            activeLevel.LoadLevel();
            StartCoroutine(StartLevels());
        }



        IEnumerator StartLevels()
        {
            if (WorldGameManager.Instance != null)
            {
                if (WorldGameManager.Instance.GameFinished == false)
                {
                    activeLevel.LoadLevel();
                }
            }
            //else
            //{
            //    activeLevel.LoadLevel();
            //}

            yield return new WaitForSeconds(activeLevel.LevelDataSO.LevelRuntimeTotal);
            if (activeLevelIndex < levels.Length-1)
            {
                if (WorldGameManager.Instance.GameFinished == false)
                {
                    Debug.Log("nit Reset Level Scene " + activeLevelIndex);
                    activeLevelIndex++;
                }
            }
            else if (activeLevelIndex == levels.Length-1)
            {
                Debug.Log("Reset Level Scene 1"+activeLevelIndex);
                activeLevelIndex = 0;
            }
            activeLevel = levels[activeLevelIndex];
            StartCoroutine(StartLevels());


        }

    }
}