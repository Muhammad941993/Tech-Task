using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] UI_Inventory _Inventory;
    [SerializeField] float Coins =0;
    Inventory inventory;

    public event Action OnBalanceChange;

    private void Awake()
    {
        inventory = new Inventory();
        _Inventory.SetInventory(inventory);
    }
    private void Start()
    {
        AddCoins(1000);
    }
    public Inventory GetInventory() => inventory;

    public float GetCurrentCoins() => Coins;

   
    public void AddCoins(float coins)
    {
        if (coins <= 0) return;
        Coins += coins;
        OnBalanceChange.Invoke();
    }
    public void RemoveCoins(float coins)
    {
        if (coins <= 0) return;
        if (coins > Coins) return;
        Coins -= coins;
        OnBalanceChange.Invoke();
    }
}
