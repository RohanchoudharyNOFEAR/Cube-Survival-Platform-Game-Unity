using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemySpawnerFB : MonoBehaviour
{
    public GameObject[] EnemiesPrefabs;
    [SerializeField]
    private float interval = 1f;
    [SerializeField]
    private Transform PlatformTransform;
    [SerializeField]
    private Transform _playerTransform;
    private EnemyParentForwardMovement _enemyMovementDirection;
    [SerializeField]
    private float _maxX, _minX;
    [SerializeField]
    private float _minZ, _maxZ;
    


    // Start is called before the first frame update
    void Start()
    {
        Start_coroutine();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpwanEnimies()
    {
        int RandomEnemySelction = Random.Range(0, 10);
        Vector3 spawnPosition = new Vector3(Random.Range(_minX, _maxX), 1.7f, Random.Range(_minZ, _maxZ));
        if (RandomEnemySelction <= 3)//simple
        {
            
            GameObject enemy = Instantiate(EnemiesPrefabs[0], spawnPosition, Quaternion.Euler(0, Random.Range(-80, 80), 0));
            setMovementDir(enemy);
            setEnemyParentToPlatform(enemy);
           
        }
        else if (RandomEnemySelction <= 6 && RandomEnemySelction >= 4)//targeted
        {
           
            GameObject enemy = Instantiate(EnemiesPrefabs[1], spawnPosition, Quaternion.Euler(0, Random.Range(-80, 80), 0));

            setEnemyParentToPlatform(enemy);
        
        }
        else if (RandomEnemySelction <= 8 && RandomEnemySelction >= 7)//bnf
        {
            
            GameObject enemy = Instantiate(EnemiesPrefabs[2], spawnPosition, Quaternion.Euler(0, Random.Range(-90, 90), 0));
            setMovementDir(enemy);
            setEnemyParentToPlatform(enemy);
           
        }
        else//jumping
        {
           
            GameObject enemy = Instantiate(EnemiesPrefabs[3], spawnPosition, Quaternion.Euler(0, Random.Range(-80, 80), 0));
            setMovementDir(enemy);
            setEnemyParentToPlatform(enemy);
           
        }

    }

    void setMovementDir(GameObject enemy)
    {
        if (_playerTransform != null)
        {
            //enemy.GetComponent<EnemyParentForwardMovement>().MovementDir = transform.right;
            
            if (enemy.transform.position.z < _playerTransform.position.z)
            {
                enemy.GetComponent<EnemyParentForwardMovement>().MovementDir = transform.forward;
            }
            else if (enemy.transform.position.z > _playerTransform.position.z)
            {
                enemy.GetComponent<EnemyParentForwardMovement>().MovementDir = -transform.forward;
            }
            
        }

        
    }

   


    void setEnemyParentToPlatform(GameObject Enemy)
    {
        Enemy.transform.SetParent(PlatformTransform);
    }


    IEnumerator startspawn()
    {
        yield return new WaitForSeconds(3f);
        while (true)
        {
            SpwanEnimies();



            yield return new WaitForSeconds(interval);
        }
    }

    public void Start_coroutine()
    {
        StartCoroutine("startspawn");
    }

    private void Stop_coroutine()
    {
        StopCoroutine("startspawn");
    }

}
