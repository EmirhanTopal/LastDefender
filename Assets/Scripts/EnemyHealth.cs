using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int enemyHealthPoint;
    [Tooltip("Adds amount of difficulty health when enemy die")]
    [SerializeField] private int difficultyHealthPoint;
    private int _currentPoint = 0;
    private Tower _tower;
    private Enemy _enemy;

    private void OnEnable()
    {
        _currentPoint = enemyHealthPoint;
    }

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Arrow"))
        {
            _tower = GameObject.FindObjectOfType<Tower>();
            _currentPoint -= _tower.arrowDamage;
        }

        if (_currentPoint <= 0)
        {
            gameObject.SetActive(false);
            enemyHealthPoint += difficultyHealthPoint;
            _enemy.Reward();
        }
    }
}
