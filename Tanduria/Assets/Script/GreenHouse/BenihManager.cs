using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BenihManager : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private FarmManager farmManager;
    [SerializeField] private Image iconBefore;
    [SerializeField] private Button plantBtn;
    [SerializeField] private Button simpanBtn;

    private InventorySO benihInventory;


    public ItemInstance selectedBenih;

    private float timer = 5;
    private bool isFilled = false;


    private void Start()
    {
        iconBefore.gameObject.SetActive(false);
        plantBtn.gameObject.SetActive(false);
        simpanBtn.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(selectedBenih == null)
        {
            isFilled = false;
            Debug.Log("Kosong");
        } else
        {
            isFilled = true;
            Debug.Log("Berisi");

        }

        if (isFilled)
        {
            iconBefore.sprite = selectedBenih.iconBefore;
            iconBefore.gameObject.SetActive(true);
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                plantBtn.gameObject.SetActive(true);
                simpanBtn.gameObject.SetActive(true);
            }
        }
    }

    public void SimpanBenih()
    {
        benihInventory.AddItem(selectedBenih);
    }
}
