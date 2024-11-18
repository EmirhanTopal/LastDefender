using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    private int _costOfTower = 30;
    private Waypoints _waypoints;
    private BankManager _bank;
    private void Start()
    {
        _waypoints = FindObjectOfType<Waypoints>();
        _bank = FindObjectOfType<BankManager>();
    }
    
    public bool HaveMoney()
    {
        if (_bank.CurrentMoney >= 30)
        {
            _bank.Withdraw(_costOfTower);
            return true;
        }

        return false;
    }
}
