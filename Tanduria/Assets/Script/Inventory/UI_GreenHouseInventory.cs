using UnityEngine;
using UnityEngine.UI;

public class UI_GreenHouseInventory : MonoBehaviour
{
    public InventorySO inventory;

    public Transform content;
    public GameObject inventorySlotPrefab;

    // Metode untuk membuat UI slot inventory
    private void CreateInventoryUI()
    {
        // Bersihkan konten sebelum membuat ulang UI
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        // Buat UI slot untuk setiap item dalam inventory
        foreach (ItemInstance itemInstance in inventory.itemList)
        {
            GameObject slotObject = Instantiate(inventorySlotPrefab, content);
            // Set up UI slot dengan informasi item
            UI_InventorySlot slot = slotObject.GetComponent<UI_InventorySlot>();
            slot.SetItem(itemInstance);
        }
    }

    private void OnEnable()
    {
        // Daftarkan metode CreateInventoryUI untuk diperbarui setiap kali game object diaktifkan
       inventory.OnInventoryChanged += CreateInventoryUI;
    }

    private void OnDisable()
    {
        // Hapus pendaftaran metode saat game object dinonaktifkan
        inventory.OnInventoryChanged -= CreateInventoryUI;
    }
}
