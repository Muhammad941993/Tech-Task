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

        activeShop?.SetActiveShooper(null);
        this.activeShop = shop;
        activeShop?.SetActiveShooper(this);

        OnActiveShopChange?.Invoke();
    }

    public Shop GetActiveShop() => activeShop;
}
