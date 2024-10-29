using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Transform _enemy;
    public int arrowDamage;
    [SerializeField] private GameObject towerTop;
    private float distance;
    
    private void Update()
    {
        FindClosestEnemy();
    }

    void FindClosestEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestEnemy = null;
        float bigNumber = Mathf.Infinity; // kontrol amaçlı ilk if i çalıştırabilmek için
        foreach (Enemy enemy in enemies)
        {
            distance = Vector3.Distance(this.transform.position, enemy.transform.position);
            if (distance < bigNumber)
            {
                bigNumber = distance;
                closestEnemy = enemy.transform;
            }
        }
        LookAtEnemy(closestEnemy);
    }
    void LookAtEnemy(Transform enemy)
    {
        if (enemy != null) // önemli nokta - burada missing reference exception hatası alıyorduk. enemy destroy olsunca halen erişmeye çalışılınıyordu.
        {
            towerTop.transform.LookAt(enemy.transform.position);
        }
    }
}
