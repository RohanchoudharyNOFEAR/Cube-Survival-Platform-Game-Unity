using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace TestOnly
{
    public class EnemeySpawnerDown : EnemySpawner
    {

       
        //[SerializeField]
        //private float _maxY;
     
      public override  void Spawn()
        {

            Vector3 spawnPosition = new Vector3(Random.Range(_minX, _maxX), _maxY, Random.Range(_minZ, _maxZ));

            NetworkObject enemy = NetworkObjectPool.Singleton.GetNetworkObject(DownwardEnemies[0], spawnPosition, Quaternion.Euler(0, Random.Range(-80, 80), 0));
            enemy.GetComponent<EnemyParentForwardMovement02>().prefab = DownwardEnemies[0];
            if (!enemy.IsSpawned)
            {
                enemy.Spawn(true);
            }

            //  GameObject enemy = Instantiate(MetorPrefab, spawnPosition, Quaternion.Euler(0, Random.Range(-80, 80), 0));
            setMovementDir(enemy.gameObject);

        }

        protected override void setMovementDir(GameObject enemy)
        {
            if (_playerTransform != null)
            {
                //enemy.GetComponent<EnemyParentForwardMovement>().MovementDir = transform.right;
                enemy.GetComponent<EnemyParentForwardMovement02>().MovementDir = -transform.up;

            }

        }

    }
}