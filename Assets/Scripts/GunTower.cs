using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GunTower : MonoBehaviour
{
    [SerializeField] private GameObject particleSystem;
    [SerializeField] [Range(10, 200)] private float rangeOfGunTower;
    [SerializeField] private GameObject gunMan;
    [SerializeField] private Animator animator;
    [SerializeField] private float slerpRotationSpeed;
    [SerializeField] private int bulletDamage;
    [SerializeField] private int costOfGunTower = 50;
    public int CostOfGunTower
    {
        get { return costOfGunTower; }
    }
    public int BulletDamage
    {
        get { return bulletDamage; }
    }
    private ParticleSystem _bulletParticle;
    private string _isFire = "fire";
    private Transform _enemyTransform;
    private float _distanceEnemy;
    private float _newDistance;
    
    private void Start()
    {
        if (particleSystem != null)
        {
            _bulletParticle = particleSystem.GetComponent<ParticleSystem>();
        }
    }

    private void Update()
    {
        FindClosestEnemy();
        LookAtEnemy();
    }

    private Transform FindClosestEnemy()
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
        return _enemyTransform;
    }

    void RotateGunMan()
    {
        Transform closestEnemy = FindClosestEnemy();
        Vector3 direction = (closestEnemy.position - gunMan.transform.position).normalized;
        Quaternion look = Quaternion.LookRotation(direction);
        gunMan.transform.rotation = Quaternion.Slerp(gunMan.transform.rotation, look, slerpRotationSpeed * Time.deltaTime);
    }
    private void LookAtEnemy()
    {
        if (_enemyTransform != null)
        {
            RotateGunMan();
            //gunMan.transform.LookAt(_enemyTransform.transform.position);
            
            float distance = Vector3.Distance(this.transform.position, _enemyTransform.position);
            if (distance < rangeOfGunTower)
            {
                var emissionModule = _bulletParticle.emission;
                if (emissionModule.enabled == false)
                {
                    FireAnim(true);
                    Attack(true);
                }
            }
            else
            {
                FireAnim(false);
                Attack(false);
            }
        }
    }
    
    private void Attack(bool isActive)
    {
        var emissionModule = _bulletParticle.emission;
        emissionModule.enabled = isActive;
    }

    private bool FireAnim(bool isFire)
    {
        animator.SetBool(_isFire, isFire);
        return isFire;
    }
}
