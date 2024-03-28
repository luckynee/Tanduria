using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GreenHouseController : MonoBehaviour
{
    [SerializeField]
    private UI_GreenHousePage greenHouseUI;

    public int greenHouseSize = 6;

    private void Start()
    {
        greenHouseUI.InitializeGreenHouseUI(greenHouseSize);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            if(greenHouseUI.isActiveAndEnabled == false)
            {
                greenHouseUI.Show();
            }
            else
            {
                greenHouseUI.Hide();
            }
        }
    }
}
