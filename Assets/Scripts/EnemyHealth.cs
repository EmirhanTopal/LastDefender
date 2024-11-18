using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int enemyHealthPoint;
    [SerializeField] private int currentPoint;
    private Tower _tower;
    private Enemy _enemy;

    private void OnEnable()
    {
        currentPoint = enemyHealthPoint;
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
            currentPoint -= _tower.arrowDamage;
        }

        if (currentPoint <= 0)
        {
            gameObject.SetActive(false);
            _enemy.Reward();
        }
    }
}
