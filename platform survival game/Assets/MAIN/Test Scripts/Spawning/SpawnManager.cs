using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

namespace TestOnly
{
    public class SpawnManager : MonoBehaviour
    {
        // public Spawner[] spawners;
        //public Spawner EnemeySpawnerDown;
        //public Spawner ForwardEnemeySpawner;
        //public Spawner BackwardEnemeySpawner;
        //public Spawner LeftEnemeySpawner;
        //public Spawner RightEnemeySpawner;

        public Level level;
        public LevelManager levelManager;

        public GameObject EnemeySpawnerDownPrefab;
        public GameObject ForwardEnemeySpawnerPrefab;
        public GameObject BackwardEnemeySpawnerPrefab;
        public GameObject LeftEnemeySpawnerPrefab;
        public GameObject RightEnemeySpawnerPrefab;
        public GameObject CollectableSpawnerPrefab;
        public GameObject AbilitySpawnerPrefab;

        [Header("only for testing")]
        public bool SpawnEnimies = true;
        public bool SpawnCollectables = true;
        public bool SpawnAbilities = true;

        private void Awake()
        {
            // spawners = GetComponentsInChildren<Spawner>();
          
        }

        private void Start()
        {
            levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
            level = levelManager.activeLevel;
            Debug.Log(levelManager.activeLevel);

            // if (!NetworkManager.Singleton.IsServer)
            // {
            // NetworkManager.Singleton.OnServerStarted += StartSpawning;
            InitializeSpawners();
            StartCoroutine(StartSpawner_Coroutine());
            //}

        }

        void InitializeSpawners()
        {
            Debug.Log("spawner initialized in scene" + SceneManager.GetActiveScene().name);
            if (level != null)
            {
                if (SpawnEnimies == true)
                {

                    EnemeySpawnerDownPrefab = Instantiate(level.LevelDataSO.DownEnemeySpawnerData.SpawnerPrefab);
                    ForwardEnemeySpawnerPrefab = Instantiate(level.LevelDataSO.ForwardEnemeySpawnerData.SpawnerPrefab);
                    BackwardEnemeySpawnerPrefab = Instantiate(level.LevelDataSO.BackwardEnemeySpawnerData.SpawnerPrefab);
                    LeftEnemeySpawnerPrefab = Instantiate(level.LevelDataSO.LeftEnemeySpawnerData.SpawnerPrefab);
                    RightEnemeySpawnerPrefab = Instantiate(level.LevelDataSO.RightEnemeySpawnerData.SpawnerPrefab);



                    //spawnManager.EnemeySpawnerDown = LevelDataSO.DownEnemeySpawnerData.EnemeySpawner;
                    //spawnManager.ForwardEnemeySpawner = LevelDataSO.ForwardEnemeySpawnerData.EnemeySpawner;
                    //spawnManager.BackwardEnemeySpawner = LevelDataSO.BackwardEnemeySpawnerData.EnemeySpawner;
                    //spawnManager.LeftEnemeySpawner = LevelDataSO.LeftEnemeySpawnerData.EnemeySpawner;
                    //spawnManager.RightEnemeySpawner = LevelDataSO.RightEnemeySpawnerData.EnemeySpawner;

                    EnemeySpawnerDownPrefab.GetComponent<EnemeySpawnerDown>().DownwardEnemies = level.LevelDataSO.DownEnemeySpawnerData.DownwardEnemies;
                    ForwardEnemeySpawnerPrefab.GetComponent<EnemySpawnerFB>().EnemiesPrefabs = level.LevelDataSO.ForwardEnemeySpawnerData.enemies;
                    BackwardEnemeySpawnerPrefab.GetComponent<EnemySpawnerFB>().EnemiesPrefabs = level.LevelDataSO.BackwardEnemeySpawnerData.enemies;
                    LeftEnemeySpawnerPrefab.GetComponent<EnemySpawnerLR>().EnemiesPrefabs = level.LevelDataSO.LeftEnemeySpawnerData.enemies;
                    RightEnemeySpawnerPrefab.GetComponent<EnemySpawnerLR>().EnemiesPrefabs = level.LevelDataSO.RightEnemeySpawnerData.enemies;


                    EnemeySpawnerDownPrefab.GetComponent<EnemeySpawnerDown>().interval = level.LevelDataSO.DownEnemeySpawnerData.Interval;
                    ForwardEnemeySpawnerPrefab.GetComponent<EnemySpawnerFB>().interval = level.LevelDataSO.ForwardEnemeySpawnerData.Interval;
                    BackwardEnemeySpawnerPrefab.GetComponent<EnemySpawnerFB>().interval = level.LevelDataSO.BackwardEnemeySpawnerData.Interval;
                    LeftEnemeySpawnerPrefab.GetComponent<EnemySpawnerLR>().interval = level.LevelDataSO.LeftEnemeySpawnerData.Interval;
                    RightEnemeySpawnerPrefab.GetComponent<EnemySpawnerLR>().interval = level.LevelDataSO.RightEnemeySpawnerData.Interval;

                }

                if (SpawnCollectables)
                {

                    if (level.LevelDataSO.ToSpawnCollectables == true)
                    {
                        CollectableSpawnerPrefab = Instantiate(level.LevelDataSO.collectableSpawnerData.SpawnerPrefab);
                        CollectableSpawnerPrefab.GetComponent<Spawner>().spawnablesItems = level.LevelDataSO.collectableSpawnerData.spawnableItems;
                        CollectableSpawnerPrefab.GetComponent<Spawner>().interval = level.LevelDataSO.collectableSpawnerData.Interval;
                    }
                }

                if (SpawnAbilities)
                {
                    if (level.LevelDataSO.ToSpawnAbilities == true)
                    {
                        AbilitySpawnerPrefab = Instantiate(level.LevelDataSO.abilitySpawnerData.SpawnerPrefab);
                        AbilitySpawnerPrefab.GetComponent<Spawner>().spawnablesItems = level.LevelDataSO.abilitySpawnerData.spawnableItems;
                        AbilitySpawnerPrefab.GetComponent<Spawner>().interval = level.LevelDataSO.abilitySpawnerData.Interval;
                    }
                }
            }

        }

        IEnumerator StartSpawner_Coroutine()
        {
            Debug.Log("started spawnning spawners");
            yield return new WaitForSeconds(1.5f);
            StartSpawning();
        }

        void StartSpawning()
        {
            //  NetworkManager.Singleton.OnServerStarted -= StartSpawning;


            //  NetworkObjectPool.Singleton.InitializePool();

            if (EnemeySpawnerDownPrefab != null)
            {
                EnemeySpawnerDownPrefab.GetComponent<EnemeySpawnerDown>().Start_coroutine();
                // EnemeySpawnerDown.Start_coroutine();
            }
            if (ForwardEnemeySpawnerPrefab != null)
            {
                ForwardEnemeySpawnerPrefab.GetComponent<EnemySpawnerFB>().Start_coroutine();
                // ForwardEnemeySpawner.Start_coroutine();
            }
            if (BackwardEnemeySpawnerPrefab != null)
            {
                BackwardEnemeySpawnerPrefab.GetComponent<EnemySpawnerFB>().Start_coroutine();
                // BackwardEnemeySpawner.Start_coroutine();
            }
            if (LeftEnemeySpawnerPrefab != null)
            {
                LeftEnemeySpawnerPrefab.GetComponent<EnemySpawnerLR>().Start_coroutine();
                // LeftEnemeySpawner.Start_coroutine();
            }
            if (RightEnemeySpawnerPrefab != null)
            {
                RightEnemeySpawnerPrefab.GetComponent<EnemySpawnerLR>().Start_coroutine();
                // RightEnemeySpawner.Start_coroutine();
            }
            if (CollectableSpawnerPrefab != null)
            {
                CollectableSpawnerPrefab.GetComponent<Spawner>().Start_coroutine();
            }
            if (AbilitySpawnerPrefab != null)
            {
                AbilitySpawnerPrefab.GetComponent<Spawner>().Start_coroutine();
            }

            //foreach (Spawner spawner in spawners)
            //{
            //    spawner.Start_coroutine();
            //}



        }


    }
}
//foreach(Spawner spawner in spawners)
//{
//    spawner.SpawnCube();
//}