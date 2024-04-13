using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private Transform uI_GreenHouse;

    private bool greenHouseTrue = false;


    private void ShowGreenHouse()
    {
        uI_GreenHouse.gameObject.SetActive(true);
        greenHouseTrue = true;
    }

    private void HideGreenHouse()
    {
        uI_GreenHouse.gameObject.SetActive(false);
        greenHouseTrue = false;
    }

    public void GreenHousePopUp()
    {
        if (!greenHouseTrue)
        {
            ShowGreenHouse();
        }
        else
        {
            HideGreenHouse();
        }
    }

}
