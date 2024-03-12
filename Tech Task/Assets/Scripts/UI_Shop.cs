using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Shop : MonoBehaviour
{
    Shopper shopper = null;
    Shop currentShop = null;
    private void Start()
    {
        shopper = GameObject.FindGameObjectWithTag("Player").GetComponent<Shopper>();

        shopper.OnActiveShopChange += UpdateShopUI;
        
    }

    private void UpdateShopUI()
    {
        currentShop = shopper.GetActiveShop();
        gameObject.SetActive(currentShop != null);
    }
}
