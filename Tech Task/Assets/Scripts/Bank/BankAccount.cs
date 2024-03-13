using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankAccount : MonoBehaviour
{
    public event Action OnBalanceChange;

    float balance = 3000;
    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();

        if(OnBalanceChange != null)
        {
            OnBalanceChange.Invoke();
        }
    }
    public void DepositToAccount(float coins)
    {
        if (coins <= 0) return;
        if (player.GetCurrentCoins() < coins) return;

        player.RemoveCoins(coins);
        balance += coins;
        OnBalanceChange.Invoke();
    }
    public void WithdrawToAccount(float coins)
    {
        if (coins <= 0) return;
        if (coins > balance) return;
        player.AddCoins(coins);
        balance -= coins;
        OnBalanceChange.Invoke();
    }
    public void IncreaseAccountBalanceByPercentage(float Percent)
    {
        float per = (Percent / 100);
        balance += balance * per;
       
        OnBalanceChange?.Invoke();
        
    }
    public float GetCurrentBalance() => balance;
}
