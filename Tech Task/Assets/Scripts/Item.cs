public class Item
{
    public enum ItemType
    {
      ItemOne, ItemTwo, ItemThree, ItemFour, ItemFive,
    }
    public ItemType Type { get; set; }
    public int amount = 0;
}
