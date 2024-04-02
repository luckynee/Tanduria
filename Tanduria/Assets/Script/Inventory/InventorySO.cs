using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory")]
public class InventorySO : ScriptableObject
{
    public int maxItems = 6;
    public int maxItemsPerSlot = 10;
    public List<ItemInstance> itemList = new List<ItemInstance>();

    // Event yang akan dipicu ketika ada perubahan pada inventory
    public event Action OnInventoryChanged;

    public bool AddItem(ItemInstance itemToAdd)
    {
        bool itemAdded = false;

        // Cari slot kosong jika ada
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i] == null)
            {
                itemList[i] = new ItemInstance(itemToAdd.itemType); // Gunakan konstruktor untuk membuat instance baru
                itemAdded = true;
                break;
            }
            else if (itemList[i].itemType == itemToAdd.itemType)
            {
                // Periksa apakah item sudah ada di inventory
                if (itemList[i].quantity < maxItemsPerSlot) // Periksa apakah slot belum penuh
                {
                    // Menambahkan jumlah item ke slot yang sudah ada
                    itemList[i].quantity++;
                    itemAdded = true;
                    break;
                }
            }
        }

        // Jika item belum ditambahkan, tambahkan item baru jika masih ada ruang di inventory
        if (!itemAdded && itemList.Count < maxItems)
        {
            itemList.Add(new ItemInstance(itemToAdd.itemType)); // Gunakan konstruktor untuk membuat instance baru
            itemAdded = true;
        }

        if (itemAdded)
        {
            // Panggil event untuk memberi tahu bahwa ada perubahan pada inventory
            OnInventoryChanged?.Invoke();
        }
        else
        {
            Debug.Log("Tidak ada ruang di inventory");
        }

        return itemAdded;
    }

    public void RemoveItem(ItemInstance itemToRemove)
    {
        int minQuantityIndex = -1;
        int minQuantity = int.MaxValue;

        // Cari slot dengan jumlah item terkecil
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i] != null && itemList[i].itemType == itemToRemove.itemType && itemList[i].quantity < minQuantity)
            {
                minQuantityIndex = i;
                minQuantity = itemList[i].quantity;
            }
        }

        // Jika ditemukan slot dengan jumlah item terkecil, kurangi jumlahnya
        if (minQuantityIndex != -1)
        {
            itemList[minQuantityIndex].quantity--;

            // Jika jumlah item mencapai 0, hapus item dari slot
            if (itemList[minQuantityIndex].quantity <= 0)
            {
                itemList.RemoveAt(minQuantityIndex);
            }

            // Panggil event untuk memberi tahu bahwa ada perubahan pada inventory
            OnInventoryChanged?.Invoke();
        }
    }
}
