using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_GreenHouseMainSlot : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI quantityText;
    public GreenHouseMainSlot greenHouseMainSlot;

    public void SetItem()
    {
        iconImage.sprite = greenHouseMainSlot.itemInstance.iconBefore;
        quantityText.text = greenHouseMainSlot.itemInstance.quantity.ToString();
    }
}
