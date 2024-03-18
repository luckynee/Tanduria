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

    public void SelectBenih(BenihManager newBenih)
    {
        if (selectBenih == newBenih)
        {
            selectBenih = null;
            isPlanting = false;
        }
        else
        {

            selectBenih = newBenih;
            isPlanting = true;
        }
    }

    public void SelectPlant(StorePlantItem newPlant)
    {
        if (selectPlant == newPlant)
        {
            Debug.Log("Deselected" + selectPlant.plant.plantName);

            selectPlant = null;
            isPlanting = false;
        }
        else
        {
                
            selectPlant = newPlant;
            Debug.Log("Selected" + selectPlant.plant.plantName);

            isPlanting = true;
        }
    }

    public void Transcation(int value)
    {
        gold += value;
        goldText.text = "$"+gold;
    }

}
