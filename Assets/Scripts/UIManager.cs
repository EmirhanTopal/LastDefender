using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private TextMeshProUGUI _moneyText;
    private BankManager _bank;
    
    private void Start()
    {
        _moneyText = GetComponent<TextMeshProUGUI>();
        _bank = FindObjectOfType<BankManager>();
    }

    private void Update()
    {
        DisplayMoneyUI();
    }

    private void DisplayMoneyUI()
    {
        _moneyText.text = $@"Gold: {_bank.CurrentMoney}";
    }
}
