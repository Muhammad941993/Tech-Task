using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public event Action OnChange;
    public List<ShopItem> shopItems;

    public IEnumerable<ShopItem> GetShopItems()
    {
        return shopItems;
    }
    bool isBuyingMode;
    public void SelectMode(bool isBuying) { }
    public bool IsBuyingMode() { return true; }
}
