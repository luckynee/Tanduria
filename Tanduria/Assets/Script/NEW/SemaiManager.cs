using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemaiManager : MonoBehaviour
{
    [SerializeField] private SemaiSlot[] semaiSlots;

    // Fungsi untuk memeriksa apakah ada slot kosong di SemaiManager
    public bool HasEmptySlot()
    {
        foreach (SemaiSlot slot in semaiSlots)
        {
            if (slot.item == null)
            {
                // Jika ditemukan slot kosong, kembalikan true
                return true;
            }
        }
        // Jika tidak ditemukan slot kosong, kembalikan false
        return false;
    }

    // Set item pada slot kosong pertama
    public void SetItem(ItemGreenHouseSO item, int quantity)
    {
        foreach (SemaiSlot slot in semaiSlots)
        {
            if (slot.item == null)
            {
                slot.SetItem(item, quantity);
                break;
            }
        }
    }

    // Metode lain yang mungkin Anda perlukan di sini
}
