using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;

namespace TestOnly
{
    public class Level : MonoBehaviour
    {
        [SerializeField] public LevelDataSO LevelDataSO;
        private SpawnManager spawnManager;

        public void LoadLevel()
        {
            NetworkManager.Singleton.SceneManager.LoadScene(LevelDataSO.SceneName, LoadSceneMode.Single);
           // SceneManager.LoadSceneAsync(LevelDataSO.SceneIndexNumber);

            Debug.Log("loaded level function called in scene" + SceneManager.GetActiveScene().name);

            //spawnManager.EnemeySpawnerDownPrefab = Instantiate(LevelDataSO.DownEnemeySpawnerData.SpawnerPrefab);
            //spawnManager.ForwardEnemeySpawnerPrefab = Instantiate(LevelDataSO.ForwardEnemeySpawnerData.SpawnerPrefab);
            //spawnManager.BackwardEnemeySpawnerPrefab = Instantiate(LevelDataSO.BackwardEnemeySpawnerData.SpawnerPrefab);
            //spawnManager.LeftEnemeySpawnerPrefab = Instantiate(LevelDataSO.LeftEnemeySpawnerData.SpawnerPrefab);
            //spawnManager.RightEnemeySpawnerPrefab = Instantiate(LevelDataSO.RightEnemeySpawnerData.SpawnerPrefab);

            //spawnManager.EnemeySpawnerDownPrefab.GetComponent<EnemeySpawnerDown>().EnemiesPrefabs = LevelDataSO.DownEnemeySpawnerData.enemies;
            //spawnManager.ForwardEnemeySpawnerPrefab.GetComponent<EnemySpawnerFB>().EnemiesPrefabs = LevelDataSO.ForwardEnemeySpawnerData.enemies;
            //spawnManager.BackwardEnemeySpawnerPrefab.GetComponent<EnemySpawnerFB>().EnemiesPrefabs = LevelDataSO.BackwardEnemeySpawnerData.enemies;
            //spawnManager.LeftEnemeySpawnerPrefab.GetComponent<EnemySpawnerLR>().EnemiesPrefabs = LevelDataSO.LeftEnemeySpawnerData.enemies;
            //spawnManager.RightEnemeySpawnerPrefab.GetComponent<EnemySpawnerLR>().EnemiesPrefabs = LevelDataSO.RightEnemeySpawnerData.enemies;


            //spawnManager.EnemeySpawnerDownPrefab.GetComponent<EnemeySpawnerDown>().interval = LevelDataSO.DownEnemeySpawnerData.Interval;
            //spawnManager.ForwardEnemeySpawnerPrefab.GetComponent<EnemySpawnerFB>().interval = LevelDataSO.ForwardEnemeySpawnerData.Interval;
            //spawnManager.BackwardEnemeySpawnerPrefab.GetComponent<EnemySpawnerFB>().interval = LevelDataSO.BackwardEnemeySpawnerData.Interval;
            //spawnManager.LeftEnemeySpawnerPrefab.GetComponent<EnemySpawnerLR>().interval = LevelDataSO.LeftEnemeySpawnerData.Interval;
            //spawnManager.RightEnemeySpawnerPrefab.GetComponent<EnemySpawnerLR>().interval = LevelDataSO.RightEnemeySpawnerData.Interval;


        }

    }
}