using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerManager : MonoBehaviour
{
    [SerializeField] int costOfTower = 30;
    private Waypoints _waypoints;
    private BankManager _bank;
    private void Start()
    {
        _waypoints = FindObjectOfType<Waypoints>();
        _bank = FindObjectOfType<BankManager>();
    }
    
    public bool HaveMoney()
    {
        if (_bank == null)
        {
            return false;
        }
        if (_bank.CurrentMoney >= costOfTower)
        {
            _bank.Withdraw(costOfTower);
            return true;
        }
        return false;
    }
}
