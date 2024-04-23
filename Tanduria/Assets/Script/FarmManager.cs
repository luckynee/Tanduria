using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FarmManager : MonoBehaviour
{

    public StorePlantItem selectPlant;
    public BenihManager selectBenih;
    public bool isPlanting = false;
    public int gold = 100;
    public TextMeshProUGUI goldText;
    public PlantSO selectedPlant;
    public InventoryBenihDoneSO inventoryBenihDoneSO;

    private List<PlotManager> plotManagers = new List<PlotManager>();


    private void Awake()
    {
        PlotManager[] foundPlotManagers = GetComponentsInChildren<PlotManager>();

        // Menambahkan setiap PlotManager yang ditemukan ke dalam list
        foreach (PlotManager plotManager in foundPlotManagers)
        {
            plotManagers.Add(plotManager);
        }

        Debug.Log("jumlah"+plotManagers.Count);
    }

    void Start()
    {
        goldText.text = gold.ToString();
    }

    public void SelectedPlant(PlantSO newPlant)
    {
        if (selectedPlant == newPlant)
        {
            selectedPlant = null;
            isPlanting = false;
        }
        else
        {
            selectedPlant = newPlant;
            isPlanting = true;
        }
    }

    public void Transcation(int value)
    {
        gold += value;
        goldText.text = "$"+gold;
    }

}
