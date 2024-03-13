using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] UI_Inventory ui_Inventory;

    float coins = 0;
    Inventory inventory;

    public event Action OnBalanceChange;

    private void Awake()
    {
        inventory = new Inventory();
        ui_Inventory.SetInventory(inventory);
    }
    private void Start()
    {
        AddCoins(1000);
    }
    public Inventory GetInventory() => inventory;

    public float GetCurrentCoins() => coins;


    public void AddCoins(float coins)
    {
        if (coins <= 0) return;
        this.coins += coins;
        OnBalanceChange.Invoke();
    }
    public void RemoveCoins(float coins)
    {
        if (coins <= 0) return;
        if (coins > this.coins) return;
        this.coins -= coins;
        OnBalanceChange.Invoke();
    }
}
