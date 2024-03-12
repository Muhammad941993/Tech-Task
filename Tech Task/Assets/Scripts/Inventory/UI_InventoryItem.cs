using UnityEngine;
using UnityEngine.UI;

public class UI_InventoryItem : MonoBehaviour
{
    [SerializeField] Image itemIcon;

    public void SetUp(InventoryItem item)
    {
        itemIcon.sprite = item.sprite;
    }
}
