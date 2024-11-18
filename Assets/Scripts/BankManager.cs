using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BankManager : MonoBehaviour
{
    [SerializeField] private int startingMoney;
    [SerializeField] int currentMoney; // manipüle edilip fazladan para aktarılabilir o yüzden private
    public int CurrentMoney // fakat farklı class lardan da erişebilmek için getter ayarladık
    {
        get { return currentMoney; }
    }
    void Awake()
    {
        currentMoney = startingMoney;
    }
    public void EarnedMoney(int amount) 
    {
        currentMoney += Mathf.Abs(amount); // amount manipüle edip - olursa diye abs kullandık
    }
    public void Withdraw(int minusAmount) // minusAmount manipüle edip - olursa diye abs kullandık
    {
        currentMoney -= Mathf.Abs(minusAmount);
        if (currentMoney < 0)
        {
            GameOver();
        }
    }
    private void GameOver()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }
}
