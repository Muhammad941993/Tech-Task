using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    private List<InventoryItem> itemList;

    public event Action OnItemListUpdated;
    public Inventory() 
    {
        itemList = new List<InventoryItem>();
    }

    public void AddItem(InventoryItem item)
    {
        itemList.Add(item);
        OnItemListUpdated();
    }

    public void RemoveItem(InventoryItem item)
    {
        itemList.Remove(item);
        OnItemListUpdated();
    }

    public List<InventoryItem> GetItemList() => itemList;
}
