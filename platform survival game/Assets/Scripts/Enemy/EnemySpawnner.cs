using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnner : MonoBehaviour
{
    public GameObject[] EnemiesPrefabs;
    private float interval =1f;
    [SerializeField]
    private Transform PlatformTransform;
    [SerializeField]
    private Transform _playerTransform;

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
        Vector3 spawnPosition = new Vector3(Random.Range(-27, 27), 1.7f, Random.Range(-27, 27)); 
        if(RandomEnemySelction<=3)
        {
            // Instantiate(EnemiesPrefabs[0], spawnPosition, Quaternion.identity);
         GameObject enemy=   Instantiate(EnemiesPrefabs[0], spawnPosition,Quaternion.Euler(0,Random.Range(-110,110),0));

            setEnemyParentToPlatform(enemy);
            setLocalScaleTowardPlayer(enemy);
        }
        else if(  RandomEnemySelction<=6 && RandomEnemySelction>=4)
        {
            //  Instantiate(EnemiesPrefabs[1], spawnPosition, Quaternion.identity);
            GameObject enemy = Instantiate(EnemiesPrefabs[1], spawnPosition, Quaternion.Euler(0, Random.Range(-110, 110), 0));

           setEnemyParentToPlatform(enemy);
            setLocalScaleTowardPlayer(enemy);
        }
        else if (RandomEnemySelction <= 8 && RandomEnemySelction >= 7)
        {
            // Instantiate(EnemiesPrefabs[2], spawnPosition, Quaternion.identity);
            GameObject enemy = Instantiate(EnemiesPrefabs[2], spawnPosition, Quaternion.Euler(0, Random.Range(-90, 90), 0));

            setEnemyParentToPlatform(enemy);
            setLocalScaleTowardPlayer(enemy);
        }
        else {
            // Instantiate(EnemiesPrefabs[3], spawnPosition, Quaternion.identity);
            GameObject enemy = Instantiate(EnemiesPrefabs[3], spawnPosition, Quaternion.Euler(0, Random.Range(-110, 110), 0));

            setEnemyParentToPlatform(enemy);
            setLocalScaleTowardPlayer(enemy);
        }

    }

    void setLocalScaleTowardPlayer(GameObject Enemy)
    {
        if(_playerTransform!=null)
        {
            if(Enemy.transform.position.z< _playerTransform.position.z)
            {
                Enemy.transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else if(Enemy.transform.position.z > _playerTransform.position.z)
            {
                Enemy.transform.localScale = new Vector3(1f, 1f, -1f);
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

    /*
    private void levelincrease()
    {
        if ()
        {
            interval = 0.8f;
        }
    }
    */

}
