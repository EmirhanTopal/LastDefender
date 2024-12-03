using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GunTower : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] [Range(10, 200)] private float rangeOfGunTower;
    [SerializeField] private GameObject gunMan;
    [SerializeField] private Animator animator;
    private string _isFire = "fire";
    private Transform _enemyTransform;
    private float _distanceEnemy;
    private float _newDistance;
    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        FindClosestEnemy();
        LookAtEnemy();
    }

    private void FindClosestEnemy()
    {
        Enemy[] enemyList = FindObjectsOfType<Enemy>();
        _distanceEnemy = Mathf.Infinity;
        Transform closestEnemy = null;
        foreach (var enemy in enemyList)
        {
            _newDistance = Vector3.Distance(this.transform.position, enemy.transform.position);
            if (_newDistance < _distanceEnemy)
            {
                _distanceEnemy = _newDistance;
                closestEnemy = enemy.transform;
            }
        }
        _enemyTransform = closestEnemy;
    }

    private void LookAtEnemy()
    {
        if (_enemyTransform != null)
        {
            gunMan.transform.LookAt(_enemyTransform.transform.position);
            
            float distance = Vector3.Distance(this.transform.position, _enemyTransform.position);
            if (distance < rangeOfGunTower)
            {
                var emissionModule = particleSystem.emission;
                if (emissionModule.enabled == false)
                {
                    AnimatorHandle(true);
                    Attack(true);
                }
            }
            else
            {
                AnimatorHandle(false);
                Attack(false);
            }
        }
    }
    
    private void Attack(bool isActive)
    {
        var emissionModule = particleSystem.emission;
        emissionModule.enabled = isActive;
    }

    private bool AnimatorHandle(bool isFire)
    {
        animator.SetBool(_isFire, isFire);
        return isFire;
    }
}
