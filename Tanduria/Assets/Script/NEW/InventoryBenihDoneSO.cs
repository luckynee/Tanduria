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

    public int RemoveItem(PlantSO item, int quantity)
    {
        int removedAmount = 0;

        if (item.IsStackable())
        {
           
            foreach (PlantSO inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    // Update jumlah item di inventaris
                    removedAmount = Mathf.Min(quantity, inventoryItem.amount);
                    inventoryItem.amount -= removedAmount;
                    if (inventoryItem.amount <= 0)
                    {
                        itemList.Remove(inventoryItem);
                    }
                    break;
                }
            }
        }
        else
        {
            // Hapus item dari inventaris jika tidak stackable
            for (int i = 0; i < quantity; i++)
            {
                if (itemList.Remove(item))
                {
                    removedAmount++;
                }
                else
                {
                    break; // Berhenti jika tidak ada lagi item yang dihapus
                }
            }
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
