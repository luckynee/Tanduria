using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Benih", menuName ="Benih")]
public class BenihSO : ScriptableObject
{
    public string benihName;
    public float pemuaianTime;
    public Sprite iconBefore;
    public Sprite iconAfter;
    public PlantSO benihPlant;
}
