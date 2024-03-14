using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Plant", menuName ="Plant")]
public class PlantSO : ScriptableObject
{
    public string plantName;
    public Sprite[] plantStages;
    public float timeBtwnStages;
    public int buyPrice;
    public int sellPrice;
    public Sprite icon;
}
