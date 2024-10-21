using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Transform _enemy;
    public int arrowDamage;
    [SerializeField] private GameObject towerTop;
    private void Start()
    {
        _enemy = GameObject.FindObjectOfType<MoveEnemy>().transform;
    }

    private void Update()
    {
        LookAtEnemy();
    }

    void LookAtEnemy()
    {
        if (_enemy != null) // önemli nokta - burada missing reference exception hatası alıyorduk. enemy destroy olsunca halen erişmeye çalışılınıyordu.
        {
            towerTop.transform.LookAt(_enemy.transform.position);
        }
    }
}
