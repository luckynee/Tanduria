using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Plant", menuName ="Plant")]
public class PlantSO : ScriptableObject
{
    public enum ItemType
    {
        Jagung,
        Bayam,
    }

    public ItemType itemType;

    public string plantName;
    public Sprite[] plantStages;
    public float timeBtwnStages;
    public int buyPrice;
    public int sellPrice;
    public Sprite icon;
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
