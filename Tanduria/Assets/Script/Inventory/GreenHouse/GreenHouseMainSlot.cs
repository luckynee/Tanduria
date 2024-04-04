using UnityEngine;

public class GreenHouseMainSlot : MonoBehaviour
{
    public ItemInstance itemInstance;

    // Metode untuk mengatur slot dengan ItemInstance dan quantitynya
    public void SetItem(ItemInstance newItemInstance)
    {
        itemInstance = newItemInstance;
    }

    // Metode untuk mendapatkan ItemInstance yang disimpan di slot
    public ItemInstance GetItemInstance()
    {
        return itemInstance;
    }
}
