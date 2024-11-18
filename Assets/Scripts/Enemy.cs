using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _rewardMoney = 25;
    private int _theifMoney = 25;
    
    private BankManager _bankManager;

    private void Start()
    {
        _bankManager = FindObjectOfType<BankManager>();
    }

    public void Reward()
    {
        if (_bankManager != null)
        {
            _bankManager.EarnedMoney(_rewardMoney);
        }
    }
    public void Theif()
    {
        if (_bankManager != null)
        {
            _bankManager.Withdraw(_theifMoney);
        }
    }
}
