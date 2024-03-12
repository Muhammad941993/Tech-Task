[System.Serializable]
public class ShopItem 
{
    public InventoryItem item { get; private set; }
    public string name;
    public float price;

    public ShopItem(InventoryItem item)
    {
        this.item = item;
        this.name = item.Name;
        this.price = item.Price;
    }
}
