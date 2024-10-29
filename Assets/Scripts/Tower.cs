using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Transform _enemy;
    public int arrowDamage;
    [SerializeField] private GameObject towerTop;
    [Range(30, 60)] [SerializeField] private float rangeOfTower;
    private ParticleSystem _arrow;
    private float _distance;

    private void Start()
    {
        _arrow = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        FindClosestEnemy();
        LookAtEnemy();
    }

    void FindClosestEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestEnemy = null;
        float bigNumber = Mathf.Infinity; // kontrol amaçlı ilk if i çalıştırabilmek için
        foreach (Enemy enemy in enemies)
        {
            _distance = Vector3.Distance(this.transform.position, enemy.transform.position);
            if (_distance < bigNumber)
            {
                bigNumber = _distance;
                Debug.Log(_distance);
                closestEnemy = enemy.transform;
            }
        }
        _enemy = closestEnemy;
    }
    void Attack(bool isActive)
    {
        var emissionModule = _arrow.emission;
        emissionModule.enabled = isActive;
    }
    
    void LookAtEnemy()
    {
        /* _distance değeri sadece en yakın enemy i buldurmak için kullanılır. 
         Fakat bu düşman sürekli hareket ettiği için mesafeyi her framde de güncellememiz gerekiyor.
        _distance değerini bu sebepten dolayı kullanamayız. */
        float newDistance = Vector3.Distance(this.transform.position, _enemy.transform.position); 
        if (newDistance < rangeOfTower)
        {
            var emissionModule = _arrow.emission;
            if (emissionModule.enabled == false)
            {
                Attack(true);
            }
        }
        else
        {
            Attack(false);
        }
        if (_enemy != null) // önemli nokta - burada missing reference exception hatası alıyorduk. enemy destroy olsunca halen erişmeye çalışılınıyordu.
        {
            towerTop.transform.LookAt(_enemy.transform.position);
        }
    }
}
