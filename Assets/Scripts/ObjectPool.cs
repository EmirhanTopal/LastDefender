using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] [Range(0.1f, 1)] private  float  spawnDuration;
    [SerializeField] private GameObject enemy;
    [SerializeField] [Range(0, 50)] private int poolSize;
    private GameObject[] _pool;

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
        while (spawnDuration > 0)
        {
            EnablePool();
            yield return new WaitForSeconds(spawnDuration);
        }
    }
}
