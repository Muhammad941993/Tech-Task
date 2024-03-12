using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopper : MonoBehaviour
{
    Shop activeShop;

    public event Action OnActiveShopChange;
    public void SetActiveShop(Shop shop)
    {
        this.activeShop = shop;
        OnActiveShopChange.Invoke();
    }

    public Shop GetActiveShop() => activeShop;
}
