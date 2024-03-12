using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] string ShopName;
    public event Action OnChange;
    Shopper activeShopper;
    [SerializeField] List<ShopItem> shopItems;

    public List<ShopItem> GetShopItems()
    {
        return shopItems;
    }
    bool isBuyingMode = true;
    public void SelectMode(bool isBuying)
    {
        isBuyingMode = isBuying;
        OnChange?.Invoke();
    }
    public bool IsBuyingMode() { return isBuyingMode; }
    public string GetShopName()
    {
        return ShopName;
    }
    public void SetActiveShooper(Shopper shopper)
    {
        this.activeShopper = shopper;
    }
    public void AddShopItem(InventoryItem item)
    {
        shopItems.Add(new ShopItem(item));
        OnChange.Invoke();
    }
    public void RemoveShopItem(ShopItem item)
    {
        shopItems.Remove(item);
        OnChange.Invoke();
    }
    public void CompleteBuyAction(ShopItem item)
    {
        var player = activeShopper.GetComponent<Player>();
        var inventory = player.GetInventory();
        if (player.GetCurrentCoins() < item.item.Price) return;
        player.RemoveCoins(item.item.Price);
        inventory.AddItem(item.item);
        RemoveShopItem(item);
    }
    public void CompleteSellAction(ShopItem item)
    {
        var player = activeShopper.GetComponent<Player>();
        var inventory = player.GetInventory();
        player.AddCoins(item.item.Price);
        inventory.RemoveItem(item.item);
        AddShopItem(item.item);
    }
}
