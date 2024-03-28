using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_GreenHouseItem : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private Image itemImageBefore;
    [SerializeField] private Image itemImageAfter;
    [SerializeField] private TextMeshProUGUI quantityTxtBefore;
    [SerializeField] private TextMeshProUGUI quantityTxtAfter;

    public event Action<UI_GreenHouseItem> OnItemClikedEmpty, OnItemClickedFilled;

    private bool empty = true;

    private void Awake()
    {
        ResetData();
    }

    public void ResetData()
    {
        this.itemImageBefore.gameObject.SetActive(false);
        this.itemImageAfter.gameObject.SetActive(false);
        empty = true;
    }

    public void SetData(Sprite sprite, int quantity)
    {
        this.itemImageBefore.gameObject.SetActive(true);
        this.itemImageBefore.sprite = sprite;
        this.quantityTxtBefore.text = quantity + "";
        empty = false;
    }

    public void SetAfterData(Sprite sprite, int quantity)
    {
        this.itemImageAfter.gameObject.SetActive(true);
        this.itemImageAfter.sprite = sprite;
        this.quantityTxtAfter.text = quantity + "";
        this.itemImageBefore.gameObject.SetActive(false);
    }

    public void OnPointerClick(BaseEventData data)
    {
        PointerEventData pointerEventData = (PointerEventData)data;
        if(pointerEventData.button == PointerEventData.InputButton.Left && empty)
        {
            OnItemClikedEmpty?.Invoke(this);
        }
        else if(pointerEventData.button == PointerEventData.InputButton.Left && !empty)
        {
            OnItemClickedFilled?.Invoke(this);
        }
    }

   
}
