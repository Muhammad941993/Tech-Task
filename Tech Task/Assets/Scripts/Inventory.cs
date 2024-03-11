using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    private List<Item> itemList;

    public Inventory() 
    {

        itemList = new List<Item>();
        AddItem(new Item{ Type = Item.ItemType.ItemOne, amount = 1 });
        AddItem(new Item { Type = Item.ItemType.ItemTwo, amount = 2 });
        AddItem(new Item { Type = Item.ItemType.ItemThree, amount = 3 });
        AddItem(new Item { Type = Item.ItemType.ItemThree, amount = 3 });
        AddItem(new Item { Type = Item.ItemType.ItemThree, amount = 3 });
        AddItem(new Item { Type = Item.ItemType.ItemThree, amount = 3 });
        AddItem(new Item { Type = Item.ItemType.ItemThree, amount = 3 });
        AddItem(new Item { Type = Item.ItemType.ItemThree, amount = 3 });
        AddItem(new Item { Type = Item.ItemType.ItemThree, amount = 3 });



        Debug.Log("inventory count : " + itemList.Count);
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
    }

    public void RemoveItem(Item item)
    {
        itemList.Remove(item);
    }

    public List<Item> GetItemList() => itemList;
}
