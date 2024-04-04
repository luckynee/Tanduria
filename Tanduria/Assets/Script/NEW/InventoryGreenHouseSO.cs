using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Inventory")]
public class InventoryGreenHouseSO : ScriptableObject
{
    public List<ItemGreenHouseSO> itemList = new List<ItemGreenHouseSO>();

    public event EventHandler OnItemListChanged;

    public void AddItem(ItemGreenHouseSO item)
    {
        if (item.IsStackable())
        {
            bool itemAlreadyInInventory = false;
            foreach (ItemGreenHouseSO inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    // Update jumlah item di inventaris jika item sudah ada
                    inventoryItem.amount += 1;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory)
            {
                // Tambahkan item ke inventaris jika item belum ada
                itemList.Add(item);
                item.amount = 1;
                
            }
        }
        else
        {
            // Tambahkan item ke inventaris jika tidak stackable
            itemList.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public int RemoveItem(ItemGreenHouseSO item)
    {
        int removedAmount = 0;

        if (item.IsStackable())
        {
            ItemGreenHouseSO itemInInventory = null;
            foreach (ItemGreenHouseSO inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    // Update jumlah item di inventaris
                    removedAmount = Mathf.Min(item.amount, inventoryItem.amount);
                    inventoryItem.amount -= removedAmount;
                    itemInInventory = inventoryItem;
                }
            }
            // Hapus item dari inventaris jika jumlah item kurang dari atau sama dengan 0
            if (itemInInventory != null && itemInInventory.amount <= 0)
            {
                itemList.Remove(itemInInventory);
            }
        }
        else
        {
            // Hapus item dari inventaris jika tidak stackable
            itemList.Remove(item);
            removedAmount = 1; // Jika tidak stackable, jumlah yang dihapus adalah 1
        }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);

        return removedAmount;
    }


    public List<ItemGreenHouseSO> GetItemList()
    {
        return itemList;
    }
    // Metode lain untuk mengelola inventaris bisa ditambahkan di sini
}
