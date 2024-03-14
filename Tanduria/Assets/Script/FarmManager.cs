using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FarmManager : MonoBehaviour
{
    public StorePlantItem selectPlant;
    public bool isPlanting = false;
    public int gold = 100;
    public TextMeshProUGUI goldText;

    // Start is called before the first frame update
    void Start()
    {
        goldText.text = gold.ToString();
    }

    // Update is called once per frame
    void Update()
    {

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
