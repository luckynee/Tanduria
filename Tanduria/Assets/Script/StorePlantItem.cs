using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StorePlantItem : MonoBehaviour
{
    public PlantSO plant;

    public TextMeshProUGUI nameTxt;
    public TextMeshProUGUI priceTxt;
    public Image icon;

    FarmManager farmManager;

    private void Awake()
    {
        farmManager = FindObjectOfType<FarmManager>();
    }

    private void Start()
    {
        InitializeUI();
    }

    public void BuyPlant()
    {
        farmManager.SelectPlant(this);
    }

    void InitializeUI()
    {
        nameTxt.text = plant.plantName;
        priceTxt.text = "" + plant.buyPrice;
        icon.sprite = plant.icon;
    }
}
