using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    private GreenHouseMain greenHouseMain;

    private void Awake()
    {
        greenHouseMain = FindObjectOfType<GreenHouseMain>(); // Mencari GreenHouseMain di scene
    }

    // Method untuk memindahkan item dari inventory ke GreenHouseMain
    public void MoveItem()
    {
        UI_InventorySlot uiSlot = GetComponentInChildren<UI_InventorySlot>(); // Mendapatkan UI_InventorySlot dari child
        if (uiSlot != null && greenHouseMain != null && uiSlot.itemInstance != null)
        {
            greenHouseMain.MoveItemToEmptySlot(uiSlot.itemInstance); // Memindahkan item ke GreenHouseMain
            Debug.Log("Item moved to GreenHouseMain: " + uiSlot.itemInstance.itemType.itemName);

            // Mencari slot kosong di GreenHouseMain dan mengubah item instance-nya
            greenHouseMain.SetEmptySlotToItemInstance(uiSlot.itemInstance);

            // Reset UI_InventorySlot
            uiSlot.SetItem(null);
        }
    }
}
