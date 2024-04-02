using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]

public class ItemDataSO : ScriptableObject
{
    public string itemName;
    public float timeSemai;
    public Sprite iconBefore;
    public PlantSO plant;
}

[System.Serializable]
public class ItemInstance
{
    public ItemDataSO itemType;
    public float timeSemai;
    public Sprite iconBefore;
    public PlantSO plant;
    public int quantity;

    public ItemInstance(ItemDataSO itemDataSO)
    {
        itemType = itemDataSO;
        timeSemai = itemDataSO.timeSemai;
        iconBefore = itemDataSO.iconBefore;
        plant = itemDataSO.plant;
        quantity = 1;
    }
}
