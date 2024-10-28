using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private float spawnDuration;
    [SerializeField] private GameObject enemy;
    private float _duration;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            _duration = Time.time;
            if (_duration / spawnDuration > 0.98f)
            {
                spawnDuration += 1;
                Debug.Log(spawnDuration);
                Debug.Log(_duration);
                Instantiate(enemy, enemy.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(spawnDuration);
            }
        }
    }
}
