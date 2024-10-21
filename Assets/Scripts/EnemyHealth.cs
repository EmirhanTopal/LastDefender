using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int enemyHealtPoint;
    private Tower _tower;
    
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Arrow"))
        {
            _tower = GameObject.FindObjectOfType<Tower>();
            enemyHealtPoint -= _tower.arrowDamage;
        }

        if (enemyHealtPoint <= 0)
        {
            Destroy(gameObject);
        }
    }
}
