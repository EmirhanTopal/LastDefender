using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private float spawnDuration;
    [SerializeField] private GameObject enemy;
    [SerializeField] private int poolSize;
    private GameObject[] _pool;
    private float _duration = 0;
    private bool iss = true;

    private void Start()
    {
        EnemyPool();
        StartCoroutine(SpawnEnemies());
    }

    void EnemyPool()
    {
        _pool = new GameObject[poolSize];
        for (int i = 0; i < _pool.Length; i++)
        {
            _pool[i] = Instantiate(enemy,transform);
            _pool[i].SetActive(false);
        }
    }

    void EnablePool()
    {
        // its working - enable object when disable in scene.
        // for (int i = 0; i < _pool.Length; i++)
        // {
        //     if (_pool[i].activeInHierarchy == false)
        //     {
        //         _pool[i].SetActive(true);
        //         break;
        //     }
        // }

        foreach (var poolObject in _pool)
        {
            if (poolObject.activeInHierarchy == false)
            {
                poolObject.SetActive(true);
                break;
            }
        }
    }
    IEnumerator SpawnEnemies()
    {
        // Recursive
        // Instantiate(enemy, enemy.transform.position, Quaternion.identity);
        // yield return new WaitForSeconds(spawnDuration);
        // StartCoroutine(SpawnEnemies());
        
        // Iterative
        while (_duration < spawnDuration)
        {
            EnablePool();
            yield return new WaitForSeconds(spawnDuration);
        }
    }
}
