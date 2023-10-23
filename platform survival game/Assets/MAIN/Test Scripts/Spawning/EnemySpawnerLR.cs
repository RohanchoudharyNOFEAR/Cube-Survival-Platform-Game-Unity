using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace TestOnly
{
    public class EnemySpawnerLR : EnemySpawner
    {
        //  private EnemyParentForwardMovement _enemyMovementDirection; //stay commented to be deleted 

     
        protected override void Start()
        {

        }
        //protected override void SpwanEnimies()
        //{
        //    int RandomEnemySelction = Random.Range(0, 10);
        //    Vector3 spawnPosition = new Vector3(Random.Range(_minX, _maxX), 1.7f, Random.Range(_minZ, _maxZ));
        //    if (RandomEnemySelction <= 3)//simple
        //    {
        //        NetworkObject enemy = NetworkObjectPool.Singleton.GetNetworkObject(EnemiesPrefabs[0], spawnPosition, Quaternion.Euler(0, Random.Range(-80, 80), 0));
        //        if (!enemy.IsSpawned)
        //        {
        //            enemy.Spawn(true);
        //        }
        //        enemy.GetComponent<EnemyParentForwardMovement02>().prefab = EnemiesPrefabs[0];

        //        // GameObject enemy = Instantiate(EnemiesPrefabs[0], spawnPosition, Quaternion.Euler(0, Random.Range(-80, 80), 0));
        //        setMovementDir(enemy.gameObject);
        //        setEnemyParentToPlatform(enemy.gameObject);

        //    }
        //    else if (RandomEnemySelction <= 6 && RandomEnemySelction >= 4)//Jumping
        //    {
        //        NetworkObject enemy = NetworkObjectPool.Singleton.GetNetworkObject(EnemiesPrefabs[1], spawnPosition, Quaternion.Euler(0, Random.Range(-80, 80), 0));
        //        if (!enemy.IsSpawned)
        //        {
        //            enemy.Spawn(true);
        //        }
        //        enemy.GetComponent<EnemyParentForwardMovement02>().prefab = EnemiesPrefabs[1];

        //        //  GameObject enemy = Instantiate(EnemiesPrefabs[1], spawnPosition, Quaternion.Euler(0, Random.Range(-80, 80), 0));
        //        setMovementDir(enemy.gameObject);
        //        setEnemyParentToPlatform(enemy.gameObject);

        //    }
        //    // THIS IS TARGETED Enemey CODE IN CHULDREN OF PARENT PREFAB KEEP IN MIND
        //    else if (RandomEnemySelction <= 8 && RandomEnemySelction >= 7)//Targeted
        //    {
        //        NetworkObject enemy = NetworkObjectPool.Singleton.GetNetworkObject(EnemiesPrefabs[2], spawnPosition, Quaternion.Euler(0, Random.Range(-90, 90), 0));
        //        if (!enemy.IsSpawned)
        //        {
        //            enemy.Spawn(true);
        //        }
        //        enemy.GetComponentInChildren<TargetedEnemy>().prefab = EnemiesPrefabs[2];
        //        //  GameObject enemy = Instantiate(EnemiesPrefabs[2], spawnPosition, Quaternion.Euler(0, Random.Range(-90, 90), 0));

        //        // setMovementDir(enemy);//commented stay
        //        setEnemyParentToPlatform(enemy.gameObject);

        //    }
        //    else//BNF
        //    {
        //        NetworkObject enemy = NetworkObjectPool.Singleton.GetNetworkObject(EnemiesPrefabs[3], spawnPosition, Quaternion.Euler(0, Random.Range(-80, 80), 0));
        //        if (!enemy.IsSpawned)
        //        {
        //            enemy.Spawn(true);
        //        }
        //        enemy.GetComponent<EnemyParentForwardMovement02>().prefab = EnemiesPrefabs[3];

        //        // GameObject enemy = Instantiate(EnemiesPrefabs[3], spawnPosition, Quaternion.Euler(0, Random.Range(-80, 80), 0));
        //        setMovementDir(enemy.gameObject);
        //        setEnemyParentToPlatform(enemy.gameObject);

        //    }
        //}

        protected override void setMovementDir(GameObject enemy)
        {
            if (_playerTransform != null)
            {
                //enemy.GetComponent<EnemyParentForwardMovement>().MovementDir = transform.right;

                if (enemy.transform.position.x < _playerTransform.position.x)
                {
                    enemy.GetComponent<EnemyParentForwardMovement02>().MovementDir = transform.right;
                }
                else if (enemy.transform.position.x > _playerTransform.position.x)
                {
                    enemy.GetComponent<EnemyParentForwardMovement02>().MovementDir = -transform.right;
                }
            }
        }

    }
}