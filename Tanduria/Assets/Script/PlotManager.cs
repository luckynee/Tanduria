using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private SpriteRenderer plant;
    [SerializeField] private Sprite[] plantStages;
    [SerializeField] private GameObject plantBtn;
    [SerializeField] private GameObject harvestBtn;

    private bool isPlanted = false;
    private int plantStage = 0;
    private float timeStages = 2f;
    private float timer;

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
            if(timer < 0 && plantStage<plantStages.Length - 1)
            {
                timer = timeStages;
                plantStage++;
                UpdatePlant();
            }
        }

        if (!isPlanted)
        {
            plantBtn.SetActive(true);
            harvestBtn.SetActive(false);
        } else if(isPlanted && plantStage == plantStages.Length - 1)
        {
            plantBtn.SetActive(false);
            harvestBtn.SetActive(true);
        }
    }

    public void Harvest()
    {
        Debug.Log("Harvest");
        isPlanted = false;
        plant.gameObject.SetActive(false);
    }

    public void Plant()
    {
        Debug.Log("Plant");
        isPlanted = true;
        plantStage = 0;
        UpdatePlant();
        timer = timeStages;
        plant.gameObject.SetActive(true);
    }

    private void UpdatePlant()
    {
        plant.sprite = plantStages[plantStage];
    }
}
