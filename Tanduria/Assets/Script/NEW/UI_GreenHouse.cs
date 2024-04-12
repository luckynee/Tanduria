using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GreenHouse : MonoBehaviour
{
    [SerializeField] private Transform UI_InventoryBenih;
    [SerializeField] private Transform UI_InventoryBenihDone;
    [SerializeField] private Transform BenihShowBtn;
    [SerializeField] private Transform BenihDoneShowBtn;

    private void Start()
    {
        UI_InventoryBenihDone.gameObject.SetActive(false);
        BenihShowBtn.gameObject.SetActive(false);
    }

    public void ShowBenihDone()
    {
        UI_InventoryBenihDone.gameObject.SetActive(true);
        HideBenih();
        BenihShowBtn.gameObject.SetActive(true);
        BenihDoneShowBtn.gameObject.SetActive(false);
    }

    private void HideBenihDone()
    {
        UI_InventoryBenihDone.gameObject.SetActive(false);
    }

    public void ShowBenih()
    {
        UI_InventoryBenih.gameObject.SetActive(true);
        HideBenihDone();
        BenihShowBtn.gameObject.SetActive(false);
        BenihDoneShowBtn.gameObject.SetActive(true);
    }

    private void HideBenih()
    {
        UI_InventoryBenih.gameObject.SetActive(false);
       
    }
}
