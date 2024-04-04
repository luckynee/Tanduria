using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_InventorySlot : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI quantityText;
    public ItemInstance itemInstance; // Menyimpan informasi ItemInstance

    // Metode untuk mengatur UI slot dengan informasi item
    public void SetItem(ItemInstance itemInstance)
    {
        this.itemInstance = itemInstance; // Simpan informasi ItemInstance

        if (itemInstance != null)
        {
            iconImage.sprite = itemInstance.itemType.iconBefore;
            quantityText.text = itemInstance.quantity.ToString();
        }
        else
        {
            // Reset UI jika itemInstance null
            iconImage.sprite = null;
            quantityText.text = "";
        }
    }

    // Method untuk mendapatkan ItemInstance yang terkait dengan slot ini
    public ItemInstance GetItemInstance()
    {
        return itemInstance;
    }
}
