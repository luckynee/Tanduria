using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GreenHouseMain : MonoBehaviour
{
    public Transform content;
    public GameObject inventorySlotPrefab;

    private List<GameObject> uiItems = new List<GameObject>();

    // Method untuk membersihkan konten UI
    public void ClearContent()
    {
        foreach (GameObject uiItem in uiItems)
        {
            Destroy(uiItem);
        }
        uiItems.Clear();
    }

    // Method untuk membuat UI item
    public void CreateUIItem(ItemInstance itemInstance)
    {
        GameObject slotObject = Instantiate(inventorySlotPrefab, content);
        UI_InventorySlot slot = slotObject.GetComponent<UI_InventorySlot>();
        slot.SetItem(itemInstance);
        uiItems.Add(slotObject);
    }
}
