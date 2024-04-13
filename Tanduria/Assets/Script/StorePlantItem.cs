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
   

    private void Start()
    {
        InitializeUI();
    }

    void InitializeUI()
    {
        nameTxt.text = plant.plantName;
        priceTxt.text = "" + plant.buyPrice;
        icon.sprite = plant.icon;
    }
}
