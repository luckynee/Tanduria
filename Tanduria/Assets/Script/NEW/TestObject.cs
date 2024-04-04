using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObject : MonoBehaviour
{
    [SerializeField] private UI_Inventory uI_Inventory;

    [SerializeField] private InventoryGreenHouseSO inventory;
    [SerializeField] private ItemGreenHouseSO item;

    private void Awake()
    {
        uI_Inventory.SetInventory(inventory);
    }

    public void BuyItem()
    {
        inventory.AddItem(item);
    }

}
