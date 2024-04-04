using UnityEngine;

public class GreenHouseMain : MonoBehaviour
{
    public InventorySO inventory;
    public UI_GreenHouseMain uiGreenHouseMain;
    public GreenHouseMainSlot[] slots;

    private void Awake()
    {
        // Inisialisasi setiap slot sebagai null saat awal
        foreach (GreenHouseMainSlot slot in slots)
        {
            slot.SetItem(null);
        }

        // Daftarkan metode RefreshUI untuk diperbarui setiap kali ada perubahan pada inventory
        inventory.OnInventoryChanged += RefreshUI;
    }

    private void OnDestroy()
    {
        // Hapus pendaftaran metode saat game object dihancurkan
        inventory.OnInventoryChanged -= RefreshUI;
    }

    // Fungsi untuk memindahkan satu slot item beserta quantitynya ke inventory lainnya
    public void MoveItemToEmptySlot(ItemInstance itemInstance)
    {
        // Cari slot kosong di GreenHouseMain
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].itemInstance == null && itemInstance.itemType.id == 0)
            {
                // Salin item dan quantity ke slot kosong
                slots[i].SetItem(itemInstance);
                slots[i].itemInstance.quantity = itemInstance.quantity;

                // Hapus item dari inventory asal
                inventory.RemoveItem(itemInstance);

                // Refresh UI setelah menambahkan item ke slot
                RefreshUI();
                return;
            }
        }

        Debug.Log("Inventory penuh");
    }
    // Fungsi untuk mengubah item instance dari slot kosong menjadi item instance dari item slot yang diklik
    public void SetEmptySlotToItemInstance(ItemInstance itemInstance)
    {
        // Cari slot kosong di GreenHouseMain
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].itemInstance == null && itemInstance.itemType.id == 0)
            {
                // Ubah item instance slot kosong menjadi item instance dari item slot yang diklik
                slots[i].SetItem(itemInstance);
                return;
            }
        }
    }


    // Metode untuk memperbarui UI GreenHouseMain
    private void RefreshUI()
    {
        // Bersihkan konten sebelum membuat ulang UI
        uiGreenHouseMain.ClearContent();

        // Buat UI untuk setiap item dalam inventory dan tambahkan ke GreenHouseMain
        foreach (ItemInstance itemInstance in inventory.itemList)
        {
            uiGreenHouseMain.CreateUIItem(itemInstance);
        }

        // Tambahkan item ke slot GreenHouseMain
        foreach (GreenHouseMainSlot slot in slots)
        {
            // Jika slot kosong, coba isi dengan item yang cocok
            if (slot.itemInstance == null)
            {
                foreach (ItemInstance itemInstance in inventory.itemList)
                {
                    if (itemInstance.itemType.id == 0)
                    {
                        slot.SetItem(itemInstance);
                        break;
                    }
                }
            }
        }
    }

    // Fungsi untuk memeriksa apakah semua slot di GreenHouseMain kosong
    public bool IsAllSlotsEmpty()
    {
        foreach (GreenHouseMainSlot slot in slots)
        {
            if (slot.itemInstance != null)
                return false;
        }
        return true;
    }
}
