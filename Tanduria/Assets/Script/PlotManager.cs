using System;
using UnityEngine;

public enum PlotState
{
    CAN_PLANT,
    PLANT_PLANTED,
    CAN_HARVEST
}

public class PlotManager : MonoBehaviour
{
    public event Action OnPlotCanPlant;
    public event Action OnPlotPlantPlanted;
    public event Action OnPlotCanHarvest;
    public event Action OnPlotPlanted;

    [Header("References")]
    [SerializeField] private SpriteRenderer plant;
    [SerializeField] private PlantSO selectedPlant;

    private FarmManager farmManager;

    private SemaiManager semaiManager;


    private PlotState state;

    public bool isLocked = true;

    private int plantStage = 0;
    private float timer;

    private void Awake()
    {
        farmManager = transform.parent.GetComponent<FarmManager>();
        semaiManager = FindAnyObjectByType<SemaiManager>();

    }

    void Update()
    {
        if (!isLocked)
        {
            if (state == PlotState.PLANT_PLANTED)
            {
                timer -= Time.deltaTime;
                if (timer < 0 && plantStage < selectedPlant.plantStages.Length - 1)
                {
                    timer = selectedPlant.timeBtwnStages;
                    plantStage++;
                    UpdatePlant();
                }
            }
            PlotStateManager();
        }
    }

    private void PlotStateManager()
    {
        switch (state)
        {
            case PlotState.CAN_PLANT:
                OnPlotCanPlant?.Invoke();
                break;
            case PlotState.PLANT_PLANTED:
                OnPlotPlantPlanted?.Invoke();
                if (plantStage == selectedPlant.plantStages.Length - 1)
                {
                    state = PlotState.CAN_HARVEST;
                }
                break;
            case PlotState.CAN_HARVEST:
                OnPlotCanHarvest?.Invoke();
                break;
        }
    }

    public void Gali()
    {
        isLocked = false;
        state = PlotState.CAN_PLANT;
    }

    public void Harvest()
    {
        Debug.Log("Harvest");
        plant.gameObject.SetActive(false);
        farmManager.Transcation(selectedPlant.sellPrice);
        state = PlotState.CAN_PLANT;
    }

    public void PlantBtn()
    {
       
        Plant(farmManager.selectedPlant);
        
    }

    private void Plant(PlantSO newPlant)
    {
        selectedPlant = newPlant;
        Debug.Log("Plant");
        farmManager.Transcation(-selectedPlant.buyPrice);
        state = PlotState.PLANT_PLANTED;

        
        farmManager.inventoryBenihDoneSO.RemoveItem(farmManager.selectedPlant, 1);

        plantStage = 0;

        UpdatePlant();

        timer = selectedPlant.timeBtwnStages;
        plant.gameObject.SetActive(true);
    }

    private void UpdatePlant()
    {
        plant.sprite = selectedPlant.plantStages[plantStage];
    }
}
