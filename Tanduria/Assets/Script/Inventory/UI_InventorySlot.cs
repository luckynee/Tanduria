using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_InventorySlot : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI quantityText;

    // Metode untuk mengatur UI slot dengan informasi item
    public void SetItem(ItemInstance itemInstance)
    {
        iconImage.sprite = itemInstance.itemType.iconBefore;
        quantityText.text = itemInstance.quantity.ToString();
    }
}
