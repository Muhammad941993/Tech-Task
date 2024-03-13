using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_Shop : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ShopName;
    [SerializeField] Button switchButton;

    Transform itemSlotContainer;
    Transform itemSlotTemp;

    Shopper shopper = null;
    Shop currentShop = null;
    private void Awake()
    {
        shopper = GameObject.FindGameObjectWithTag("Player").GetComponent<Shopper>();
        switchButton.onClick.AddListener(SwitchMode);

        itemSlotContainer = transform.Find("shopItemContainer");
        itemSlotTemp = itemSlotContainer.Find("shopItemTemp");

        shopper.OnActiveShopChange += ShopChange;
    }
  
    private void ShopChange()
    {
        if(currentShop != null)
        {
            currentShop.OnChange -= UpdateShopUI;

        }
        currentShop = shopper.GetActiveShop();
        gameObject.SetActive(currentShop != null);

        ShopName.text = currentShop?.GetShopName();

        if (currentShop != null)
        {
            currentShop.OnChange += UpdateShopUI;
        }

        UpdateShopUI();
    }

    private void UpdateShopUI()
    {
        foreach (Transform item in itemSlotContainer)
        {
            if (item == itemSlotTemp) continue;

            Destroy(item.gameObject);
        }

        var myswitchButton = switchButton.GetComponentInChildren<TextMeshProUGUI>();
        
        if (currentShop.IsBuyingMode())
        {
            InstantiateShopItem();
            myswitchButton.text = "Switch To Sell";
        }
        else
        {
            InstantiatePlayerItem();
            myswitchButton.text = "Switch To Buy";
        }

    }
    void InstantiateShopItem()
    {
        foreach (var item in currentShop.GetShopItems())
        {
            var row = Instantiate(itemSlotTemp, itemSlotContainer);
            row.gameObject.SetActive(true);

            var uI_Row = row.GetComponent<UI_Row>();
            uI_Row.SetUp(currentShop, item );
        }
    }

    void InstantiatePlayerItem()
    {
        var itemList = shopper.GetComponent<Player>().GetInventory().GetItemList();
        foreach (var item in itemList)
        {
            var row = Instantiate(itemSlotTemp, itemSlotContainer);
            row.gameObject.SetActive(true);

            var uI_Row = row.GetComponent<UI_Row>();
            uI_Row.SetUp(currentShop, new ShopItem(item));
        }
    }

    public void SwitchMode()
    {
        currentShop.SelectMode(!currentShop.IsBuyingMode());
    }
    public void Close()
    {
        currentShop.OnChange -= UpdateShopUI;
        shopper.OnActiveShopChange -= ShopChange;
        shopper.SetActiveShop(null);
    }
   

   
}
