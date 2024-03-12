using UnityEngine;
[System.Serializable]
public class InventoryItem 
{ 
    public ItemType Type;
    public string Name;
    public float Price;
    public Sprite sprite;
}

[System.Serializable]
public enum ItemType
{
    none, food, drink, sword, shild,
}