using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory")]

public class InventorySO : ScriptableObject
{
    public int maxItems = 6;
    public int maxItemsPerSlot = 10;
    public List<ItemInstance> itemList = new List<ItemInstance>();

    public bool AddItem(ItemInstance itemToAdd)
    {
        bool itemAdded = false;

        // Finds an empty slot if there is one
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i] == null)
            {
                itemList[i] = itemToAdd;
                itemAdded = true;
                break;
            }
            else if (itemList[i].itemType == itemToAdd.itemType)
            {
                // Check if the item is already in the inventory
                if (itemList[i].quantity < maxItemsPerSlot) // Check if the slot is not full
                {
                    itemList[i].quantity++; // Increase the quantity of the item
                    itemAdded = true;
                    break;
                }
            }
        }

        // If item hasn't been added yet, find a slot to add the item
        if (!itemAdded)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                if (itemList[i].quantity < maxItemsPerSlot) // Check if the slot is not full
                {
                    itemList[i] = itemToAdd;
                    itemList[i].quantity = 1; // Reset quantity to 1 for the new slot
                    itemAdded = true;
                    break;
                }
            }
        }

        // If item still hasn't been added, add a new item if the inventory has space
        if (!itemAdded && itemList.Count < maxItems)
        {
            itemList.Add(itemToAdd);
            itemAdded = true;
        }

        if (!itemAdded)
        {
            Debug.Log("No space in the inventory");
        }

        return itemAdded;
    }





}


