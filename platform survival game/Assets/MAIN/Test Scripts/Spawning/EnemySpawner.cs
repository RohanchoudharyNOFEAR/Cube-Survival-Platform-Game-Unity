using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace TestOnly
{
    public class EnemySpawner : Spawner
    {
        //for each enemy
        [SerializeField] int maxPrefabCount = 8;

        public GameObject[] EnemiesPrefabs;
        public GameObject[] DownwardEnemies;
       
        [SerializeField]
        protected Transform PlatformTransform;
        [SerializeField]
        protected Transform _playerTransform;
       

      //  public GameObject MetorPrefab;

      

        protected override void Start()
        {

        }

       //public void SpawnCube()
       // {
       //     NetworkObject enemy = NetworkObjectPool.Singleton.GetNetworkObject(cube, new Vector3(Random.Range(_minX,_maxX),1,Random.Range(_minZ,_maxZ)), Quaternion.identity);
       //     Debug.Log("enemy spawnd");
       //     enemy.Spawn(true);
       // }


        public override void Spawn()
        {
            int RandomEnemySelction = Random.Range(0, 10);
            Vector3 spawnPosition = new Vector3(Random.Range(_minX, _maxX), 1.7f, Random.Range(_minZ, _maxZ));
            if (RandomEnemySelction <= 3)//simple
            {
                //if (NetworkObjectPool.Singleton.GetCurrentPrefabCount(EnemiesPrefabs[0]) < maxPrefabCount)
                //{
                if (EnemiesPrefabs[0] == null) { return; }
                NetworkObject enemy = NetworkObjectPool.Singleton.GetNetworkObject(EnemiesPrefabs[0], spawnPosition, Quaternion.Euler(0, Random.Range(-80, 80), 0));
                    if (!enemy.IsSpawned)
                    {
                        enemy.GetComponent<EnemyParentForwardMovement02>().prefab = EnemiesPrefabs[0];
                       
                        enemy.Spawn(true);
                    enemy.GetComponent<EnemyParentForwardMovement02>().start_Destroy();
                }
                  
                   // enemy.GetComponent<EnemyParentForwardMovement02>().networkObject = enemy;
                    // GameObject enemy = Instantiate(EnemiesPrefabs[0], spawnPosition, Quaternion.Euler(0, Random.Range(-80, 80), 0));
                    setMovementDir(enemy.gameObject);
                  //  setEnemyParentToPlatform(enemy.gameObject);
                //}

            }
            else if (RandomEnemySelction <= 6 && RandomEnemySelction >= 4)//Jumping
            {
                //if (NetworkObjectPool.Singleton.GetCurrentPrefabCount(EnemiesPrefabs[1]) < maxPrefabCount)
                //{
                if (EnemiesPrefabs[1] == null) { return; }
                NetworkObject enemy = NetworkObjectPool.Singleton.GetNetworkObject(EnemiesPrefabs[1], spawnPosition, Quaternion.Euler(0, Random.Range(-80, 80), 0));
                    if (!enemy.IsSpawned)
                    {
                        enemy.GetComponent<EnemyParentForwardMovement02>().prefab = EnemiesPrefabs[1];
                
                    enemy.Spawn(true);
                    enemy.GetComponent<EnemyParentForwardMovement02>().start_Destroy();
                }
                

                    //  GameObject enemy = Instantiate(EnemiesPrefabs[1], spawnPosition, Quaternion.Euler(0, Random.Range(-80, 80), 0));
                    setMovementDir(enemy.gameObject);
                   // setEnemyParentToPlatform(enemy.gameObject);
             //  }

            }
            // THIS IS TARGETED Enemey CODE IN CHULDREN OF PARENT PREFAB KEEP IN MIND
            else if (RandomEnemySelction <= 8 && RandomEnemySelction >= 7)//Targeted
            {
                //if (NetworkObjectPool.Singleton.GetCurrentPrefabCount(EnemiesPrefabs[2]) < maxPrefabCount)
                //{
                if(EnemiesPrefabs[2]== null) { return; }
                    NetworkObject enemy = NetworkObjectPool.Singleton.GetNetworkObject(EnemiesPrefabs[2], spawnPosition, Quaternion.Euler(0, Random.Range(-90, 90), 0));
                    if (!enemy.IsSpawned)
                    {
                    enemy.GetComponent<TargetEnemyParent>().prefab = EnemiesPrefabs[2];
                   // enemy.GetComponentInChildren<TargetedEnemy>().prefab = EnemiesPrefabs[2];
                      
                        enemy.Spawn(true);
                    enemy.GetComponentInChildren<TargetedEnemy>().start_Destroy();
                }
                  
                    //  GameObject enemy = Instantiate(EnemiesPrefabs[2], spawnPosition, Quaternion.Euler(0, Random.Range(-90, 90), 0));

                    // setMovementDir(enemy);//commented stay
                    setEnemyParentToPlatform(enemy.gameObject);
               // }

            }
            else//BNF
            {
                //if (NetworkObjectPool.Singleton.GetCurrentPrefabCount(EnemiesPrefabs[3]) < maxPrefabCount)
                //{
                if (EnemiesPrefabs[3] == null) { return; }
                NetworkObject enemy = NetworkObjectPool.Singleton.GetNetworkObject(EnemiesPrefabs[3], spawnPosition, Quaternion.Euler(0, Random.Range(-80, 80), 0));
                    if (!enemy.IsSpawned)
                    {
                        enemy.GetComponent<EnemyParentForwardMovement02>().prefab = EnemiesPrefabs[3];
                   
                    enemy.Spawn(true);
                    enemy.GetComponent<EnemyParentForwardMovement02>().start_Destroy();
                }
                  

                    // GameObject enemy = Instantiate(EnemiesPrefabs[3], spawnPosition, Quaternion.Euler(0, Random.Range(-80, 80), 0));
                    setMovementDir(enemy.gameObject);
                  //  setEnemyParentToPlatform(enemy.gameObject);
               // }

            }
        }


        protected virtual void setEnemyParentToPlatform(GameObject Enemy)
        {
            Enemy.transform.SetParent(PlatformTransform);
        }

        protected virtual void setMovementDir(GameObject enemy)
        {

        }


        //public override IEnumerator startspawn()
        //{
        //    yield return new WaitForSeconds(3f);
        //    while (true)
        //    {
        //        Spawn();
        //        yield return new WaitForSeconds(interval);
        //    }
        //}

        //public void Start_coroutine()
        //{
        //    StartCoroutine("startspawn");
        //}

        //public void Stop_coroutine()
        //{
        //    StopCoroutine("startspawn");
        //}


    }
}

//public void SpawnObject()
// {
//     NetworkObject obj = NetworkObjectPool.Singleton.GetNetworkObject(prefab, GetRandomPosition(), Quaternion.identity);
//     obj.Spawn(true);
// }

//Vector3 GetRandomPosition()
//{
//    Vector3 spawnPosition = new Vector3(Random.Range(_minX, _maxX), 1.7f, Random.Range(_minZ, _maxZ));
//    return spawnPosition;
//}