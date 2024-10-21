using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private GameObject _enemy;
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
        transform.LookAt(_enemy.transform.position);
    }
}
