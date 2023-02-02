using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemeySpawnerDown : MonoBehaviour
{
    //  public GameObject[] EnemiesPrefabs;
    public GameObject MetorPrefab;
    [SerializeField]
    private float interval = 1f;
  //  [SerializeField]
  //  private Transform PlatformTransform;
    [SerializeField]
    private Transform _playerTransform;
    private EnemyParentForwardMovement _enemyMovementDirection;
    [SerializeField]
    private float _maxX, _minX;
    [SerializeField]
    private float _minZ, _maxZ;
    [SerializeField]
    private float _maxY;



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
       
        Vector3 spawnPosition = new Vector3(Random.Range(_minX, _maxX), _maxY, Random.Range(_minZ, _maxZ));
       
            GameObject enemy = Instantiate(MetorPrefab, spawnPosition, Quaternion.Euler(0, Random.Range(-80, 80), 0));
            setMovementDir(enemy);
              
    }

    void setMovementDir(GameObject enemy)
    {
        if (_playerTransform != null)
        {
            //enemy.GetComponent<EnemyParentForwardMovement>().MovementDir = transform.right;
            enemy.GetComponent<EnemyParentForwardMovement>().MovementDir = -transform.up;
          
        }

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
