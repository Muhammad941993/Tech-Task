using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    Transform itemSlotContainer;
    Transform itemSlotTemp;

    
    private void Start()
    {
        itemSlotContainer = transform.Find("ItemSlotContainer");
        itemSlotTemp = itemSlotContainer.Find("itemSlotTemp");

        inventory.OnItemListUpdated += RefreshInventoryItems;

    }


    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }

    public void RefreshInventoryItems()
    {
        foreach (Transform item in itemSlotContainer)
        {
            if(item == itemSlotTemp) continue;

            Destroy(item.gameObject);
        }

        print(inventory.GetItemList().Count);
        for (int i = 0,x = inventory.GetItemList().Count; i < x; i++)
        {
            Instantiate(itemSlotTemp, itemSlotContainer).gameObject.SetActive(true);
        }
       
    }

    private void OnDestroy()
    {
        inventory.OnItemListUpdated -= RefreshInventoryItems;
    }
}
