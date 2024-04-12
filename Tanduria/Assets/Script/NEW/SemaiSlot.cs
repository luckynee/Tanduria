using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SemaiSlot : MonoBehaviour
{
    public ItemGreenHouseSO item;

    [SerializeField] private InventoryBenihDoneSO inventoryBenihDone;

    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI quantityText;

    private float timer;
    private int quantity;

    private void Update()
    {
        if (item != null)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
              
            }
        }

        if (quantity < 1)
        {
            quantityText.gameObject.SetActive(false);
        }
        else
        {
            quantityText.gameObject.SetActive(true);
        }
    }

    public void SetItem(ItemGreenHouseSO item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
        image.sprite = item.itemSprite;
        quantityText.text = quantity.ToString();
        timer = item.semaiTime;
    }

    public void Tanam()
    {

    }

    public void Simpan()
    {
        inventoryBenihDone.AddItem(item.plant, quantity);

        ResetItem();
    }

    private void ResetItem()
    {
        quantity = 0;
        item = null;
        image.sprite = null;
        timer = 0;
    }
}
