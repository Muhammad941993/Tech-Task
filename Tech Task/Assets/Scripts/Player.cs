using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] UI_Inventory _Inventory;

    Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory();
        _Inventory.SetInventory(inventory);
    }
    // Start is called before the first frame update
    void Start()
    {
       

    }

  
}
