using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private float spawnDuration;
    [SerializeField] private GameObject enemy;
    private float _duration = 0;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
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
            Instantiate(enemy,transform);
            yield return new WaitForSeconds(spawnDuration);
        }
    }
}
