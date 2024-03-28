using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GreenHousePage : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private UI_GreenHouseItem itemPrefab;
    [SerializeField] private RectTransform contentPanel;

    List<UI_GreenHouseItem> listOfUIItem = new List<UI_GreenHouseItem>();

    public void InitializeGreenHouseUI(int greenHouseSize)
    {
        for (int i = 0; i < greenHouseSize; i++)
        {
            UI_GreenHouseItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentPanel);
            listOfUIItem.Add(uiItem);
            uiItem.OnItemClikedEmpty += UiItem_OnItemClikedEmpty;
            uiItem.OnItemClickedFilled += UiItem_OnItemClickedFilled;
        }
    }

    private void UiItem_OnItemClickedFilled(UI_GreenHouseItem obj)
    {
        Debug.Log("Collect benih");

    }

    private void UiItem_OnItemClikedEmpty(UI_GreenHouseItem obj)
    {
        Debug.Log("Masukkan benih");
        
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
