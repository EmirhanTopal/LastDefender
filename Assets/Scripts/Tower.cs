using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private GameObject _enemy;
    [SerializeField] private GameObject towerTop;
    private void Start()
    {
        _enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    private void Update()
    {
        LookAtEnemy();
    }

    void LookAtEnemy()
    {
        towerTop.transform.LookAt(_enemy.transform.position);
    }
}
