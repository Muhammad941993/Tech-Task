using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankAccount : MonoBehaviour
{
    float Balance = 3000;
    public event Action OnBalanceChange;
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
        Balance += coins;
        OnBalanceChange.Invoke();
    }
    public void WithdrawToAccount(float coins)
    {
        if (coins <= 0) return;
        if (coins > Balance) return;
        player.AddCoins(coins);
        Balance -= coins;
        OnBalanceChange.Invoke();
    }
    public void IncreaseAccountBalanceByPercentage(float Percent)
    {
        float per = (Percent / 100);
        Balance += Balance * per;
       
        OnBalanceChange?.Invoke();
        
    }
    public float GetCurrentBalance() => Balance;
}
