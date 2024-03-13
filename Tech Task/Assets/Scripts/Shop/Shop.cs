using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public event Action OnChange;

    [SerializeField] string shopName;
    [SerializeField] List<ShopItem> shopItems;

    Shopper activeShopper;

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
        return shopName;
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
        if (player.GetCurrentCoins() < item.Item.Price) return;
        player.RemoveCoins(item.Item.Price);
        inventory.AddItem(item.Item);
        RemoveShopItem(item);
    }
    public void CompleteSellAction(ShopItem item)
    {
        var player = activeShopper.GetComponent<Player>();
        var inventory = player.GetInventory();
        player.AddCoins(item.Item.Price);
        inventory.RemoveItem(item.Item);
        AddShopItem(item.Item);
    }
}
