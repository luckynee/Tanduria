using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public GameObject plantItem;
    List<PlantSO> plantSO = new List<PlantSO>();

    private void Awake()
    {
        //Assets/Resources/Plants
        var loadPlants = Resources.LoadAll("Plants", typeof(PlantSO));
        foreach (var plant in loadPlants)
        {
            plantSO.Add((PlantSO)plant);
            
        }
        plantSO.Sort(SortingByPrice);
        foreach (var plant in plantSO)
        {

            StorePlantItem newPlant = Instantiate(plantItem, transform).GetComponent<StorePlantItem>();
            newPlant.plant = plant;
        }
    }

    private int SortingByPrice(PlantSO plantSO1,PlantSO plantSO2)
    {
        return plantSO1.buyPrice.CompareTo(plantSO2.buyPrice);
    }
}
