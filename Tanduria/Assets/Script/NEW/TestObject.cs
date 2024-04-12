using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObject : MonoBehaviour
{
    [SerializeField] private UI_Inventory uI_Inventory;

    [SerializeField] private InventoryGreenHouseSO inventory;
    [SerializeField] private ItemGreenHouseSO item;

    [SerializeField] private InventoryBenihDoneSO inventoryBenihDone;
    [SerializeField] private UI_InventoryBenihDone uI_InventoryBenihDone;

    private void Awake()
    {
        uI_Inventory.SetInventory(inventory);
        uI_InventoryBenihDone.SetInventory(inventoryBenihDone);
    }

    public void BuyItem()
    {
        inventory.AddItem(item);
    }

}
