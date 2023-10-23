using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestOnly
{
    [CreateAssetMenu(menuName = "Level Data/Level")]
    public class LevelDataSO : ScriptableObject
    {
        public LevelDefficulty LevelDefficulty;
       // public int SceneIndexNumber;
        public string SceneName;
        public int LevelRuntimeTotal;
        public bool ToSpawnCollectables;
        public bool ToSpawnAbilities = true;


        [Header("DownEnemeySpawnners")]
        public EnemeySpawnerData DownEnemeySpawnerData;

        [Header("FrontEnemeySpawnners")]
        public EnemeySpawnerData ForwardEnemeySpawnerData;

        [Header("BackwardEnemeySpawnners")]
        public EnemeySpawnerData BackwardEnemeySpawnerData;

        [Header("left to right EnemeySpawnners")]
        public EnemeySpawnerData  LeftEnemeySpawnerData;

        [Header("SidewaysEnemeySpawnners")]
        public EnemeySpawnerData RightEnemeySpawnerData;

        [Header("Collectables Spawner")]
        public CollectableSpawnerData collectableSpawnerData;

        [Header("Ability Spawner")]
        public CollectableSpawnerData abilitySpawnerData;
    }
  
   [System.Serializable]
    public struct EnemeySpawnerData 
    {
        public GameObject SpawnerPrefab;
        public EnemySpawner EnemeySpawner;
        public int Interval;
        public GameObject[] enemies;
        public GameObject[] DownwardEnemies;
    }

    [System.Serializable]
    public struct CollectableSpawnerData
    {
        public GameObject SpawnerPrefab;
      //  public EnemySpawner EnemeySpawner;
        public int Interval;
        public GameObject[] spawnableItems;
       
    }

    public enum LevelDefficulty
    {
        easy,
        medium,
        hard
    }
}