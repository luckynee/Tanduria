using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
   public enum ItemType
    {
        Jagung,
        Bayam,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
                case ItemType.Jagung: return ItemAssets.Instance.jagungSprite;
                case ItemType.Bayam: return ItemAssets.Instance.bayamSprite;
        }
    }

    public bool IsStackable()
    {
        switch(itemType)
        {
            default:
            case ItemType.Jagung:
            case ItemType.Bayam:
                return true;
        }
    }
}
