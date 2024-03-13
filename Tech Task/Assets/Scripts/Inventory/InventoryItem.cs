using UnityEngine;
[System.Serializable]
public class InventoryItem 
{ 
    public ItemType Type;
    public string Name;
    public float Price;
    public Sprite Sprite;
}

[System.Serializable]
public enum ItemType
{
    None, Food, Drink, Sword, Shild,
}