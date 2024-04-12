using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Benih Done", menuName = "Inventory/InventoryBenihDone")]
public class InventoryBenihDoneSO : ScriptableObject
{
    public List<PlantSO> itemList = new List<PlantSO>();

    public event EventHandler OnItemListChanged;

    public void AddItem(PlantSO item , int quantity)
    {
        if (item.IsStackable())
        {
            bool itemAlreadyInInventory = false;
            foreach (PlantSO inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    // Update jumlah item di inventaris jika item sudah ada
                    inventoryItem.amount += quantity;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory)
            {
                // Tambahkan item ke inventaris jika item belum ada
                itemList.Add(item);
                item.amount = quantity;

            }
        }
        else
        {
            // Tambahkan item ke inventaris jika tidak stackable
            itemList.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public int RemoveItem(PlantSO item)
    {
        int removedAmount = 0;

        if (item.IsStackable())
        {
            PlantSO itemInInventory = null;
            foreach (PlantSO inventoryItem in itemList)
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


    public List<PlantSO> GetItemList()
    {
        return itemList;
    }
    // Metode lain untuk mengelola inventaris bisa ditambahkan di sini
}
