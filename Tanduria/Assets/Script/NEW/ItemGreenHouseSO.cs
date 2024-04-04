using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemGreenHouseSO : ScriptableObject
{
    public enum ItemType
    {
        Jagung,
        Bayam,
    }

    public ItemType itemType;
    public Sprite itemSprite;
    public PlantSO plant;
    public int semaiTime;
    public int amount;

    public bool IsStackable()
    {
        switch (itemType)
        {
            default:
            case ItemType.Jagung:
            case ItemType.Bayam:
                return true;
        }


    }
}
