using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotVisual : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private GameObject plantBtn;
    [SerializeField] private GameObject galiBtn;
    [SerializeField] private GameObject harvestBtn;

    private PlotManager plotManager;

    private void Awake()
    {
        plotManager = GetComponentInParent<PlotManager>();
    }

    private void Start()
    {
        plotManager.OnPlotCanPlant += PlotManager_OnPlotCanPlant;
        plotManager.OnPlotPlantPlanted += PlotManager_OnPlotPlantPlanted;
        plotManager.OnPlotCanHarvest += PlotManager_OnPlotCanHarvest;

        HideGaliBtn();
        HideHarvestBtn();
        HidePlantBtn();
    }

    private void PlotManager_OnPlotCanHarvest()
    {
        ShowHarvestBtn();
    }

    private void PlotManager_OnPlotPlantPlanted()
    {
        HidePlantBtn();
    }

    private void PlotManager_OnPlotCanPlant()
    {
       ShowPlantBtn();
        HideHarvestBtn() ;
    }

    private void Update()
    {
        if (plotManager.isLocked)
        {
            ShowGaliBtn();
        } else
        {
            HideGaliBtn();
        }
    }

    private void ShowGaliBtn()
    {
        galiBtn.SetActive(true);
    }

    private void HideGaliBtn()
    {
        galiBtn.SetActive(false);
    }

    private void ShowPlantBtn()
    {
        plantBtn.SetActive(true);
    }

    private void HidePlantBtn()
    {
        plantBtn.SetActive(false);
    }

    private void ShowHarvestBtn()
    {
        harvestBtn.SetActive(true);
    }

    private void HideHarvestBtn()
    {
        harvestBtn.SetActive(false);
    }
}
