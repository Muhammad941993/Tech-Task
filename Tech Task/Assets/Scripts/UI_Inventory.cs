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
        RefreshInventoryItems();
    }


    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }

    public void RefreshInventoryItems()
    {
        RectTransform _transform = itemSlotContainer.GetComponent<RectTransform>();
        float x = 0, y = 0, itemSize = 130;

        foreach (var item in inventory.GetItemList())
        {
            var recTransform = Instantiate(itemSlotTemp, itemSlotContainer).GetComponent<RectTransform>();
            recTransform.gameObject.SetActive(true);
            recTransform.anchoredPosition = new Vector2(x * itemSize, y * itemSize);

            x++;
            if (x >= 3)
            {
                x = 0;
                y++;
            }
        }
    }
}
