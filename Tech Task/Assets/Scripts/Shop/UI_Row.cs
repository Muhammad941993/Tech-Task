using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Row : MonoBehaviour
{
    [SerializeField] Image itemImage;
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemPrice;
    [SerializeField] Button buyButton;
    private void Start()
    {
        buyButton.onClick.AddListener(ShopItemAction);
    }


    Shop shop = null;
    ShopItem shopItem = null;
    public void SetUp(Shop shop , ShopItem shopItem )
    {
        this.shop = shop;
        this.shopItem = shopItem;
        itemImage.sprite = shopItem.item.sprite;
        itemName.text = shopItem.item.Name;
        itemPrice.text = shopItem.item.Price.ToString();

        var ButtonText = buyButton.GetComponentInChildren<TextMeshProUGUI>();


        ButtonText.text = (shop.IsBuyingMode()) ? "Buy" : "Sell";
        
    }

    public void ShopItemAction()
    {
        if (shop.IsBuyingMode())
        {
            shop.CompleteBuyAction(shopItem);

        }
        else
        {
            shop.CompleteSellAction(shopItem);
        }
    }
}
