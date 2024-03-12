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

        foreach (var item in inventory.GetItemList())
        {
            var newitem = Instantiate(itemSlotTemp, itemSlotContainer);
            newitem.gameObject.SetActive(true);
            newitem.gameObject.GetComponent<UI_InventoryItem>().SetUp(item);
        }
    }

    private void OnDestroy()
    {
        inventory.OnItemListUpdated -= RefreshInventoryItems;
    }
}
