using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private SpriteRenderer plant;
    [SerializeField] private GameObject plantBtn;
    [SerializeField] private GameObject harvestBtn;
    [SerializeField] private GameObject galiBtn;
    [SerializeField] private PlantSO selectedPlant;

    private FarmManager farmManager;

    private bool isPlanted = false;
    private bool isPlantable = false;
    private int plantStage = 0;
    private float timer;

    private void Awake()
    {
        farmManager = transform.parent.GetComponent<FarmManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isPlanted )
        {
            timer -= Time.deltaTime;
            if(timer < 0 && plantStage< selectedPlant.plantStages.Length - 1)
            {
                timer = selectedPlant.timeBtwnStages;
                plantStage++;
                UpdatePlant();
            }
        }

        if(isPlantable )
        {
            galiBtn.SetActive(false);

            if (farmManager.isPlanting)
            {
                plantBtn.SetActive(true);
                harvestBtn.SetActive(false);
            }
            else if (isPlanted && plantStage == selectedPlant.plantStages.Length - 1)
            {
                harvestBtn.SetActive(true);
            }
            else
            {
                plantBtn.SetActive(false);
            }
        } else
        {
            galiBtn.SetActive(true);
            plantBtn.SetActive(false);
            harvestBtn.SetActive(false);
        }


    }

    public void Gali()
    {
        isPlantable = true;
    }

    public void Harvest()
    {
        Debug.Log("Harvest");
        isPlanted = false;
        plant.gameObject.SetActive(false);
    }

    public void PlantBtn()
    {
        Plant(farmManager.selectPlant.plant);
    }

    private void Plant(PlantSO newPlant)
    {
        selectedPlant = newPlant;
        Debug.Log("Plant");
        isPlanted = true;
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
