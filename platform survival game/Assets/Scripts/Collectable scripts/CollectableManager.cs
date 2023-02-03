using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    public GameObject CollectablePrefab;
    [SerializeField]
    private float interval = 5f;
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

    void SpwanCollectable()
    {


        Vector3 spawnPosition = new Vector3(Random.Range(_minX, _maxX), _maxY, Random.Range(_minZ, _maxZ));

        GameObject collectable = Instantiate(CollectablePrefab, spawnPosition, Quaternion.identity);
        

    }

    IEnumerator startspawn()
    {
        yield return new WaitForSeconds(3f);
        while (true)
        {
            SpwanCollectable();
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
