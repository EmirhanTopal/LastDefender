using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int enemyHealthPoint;
    [SerializeField] private int currentPoint;
    private Tower _tower;

    private void OnEnable()
    {
        currentPoint = enemyHealthPoint;
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
        }
    }
}
