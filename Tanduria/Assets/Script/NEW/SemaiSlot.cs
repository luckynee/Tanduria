using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SemaiSlot : MonoBehaviour
{
    public ItemGreenHouseSO item;

    [SerializeField] private InventoryBenihDoneSO inventoryBenihDone;

    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI quantityText;

    [SerializeField] private Image UI_BarInside;

    [SerializeField] private GameObject simpanBtn;

    private FarmManager farmManager;

    private float timer;
    private float barTimer;
    private float barFillSpeed;
    public int quantity;

    private void Start()
    {
        farmManager = FindAnyObjectByType<FarmManager>();
        simpanBtn.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (item != null)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                simpanBtn.gameObject.SetActive(true);

            }
            else
            {
                barFillSpeed = 1f / barTimer;
                UI_BarInside.fillAmount = 1 - (timer / barTimer);
            }

        } else
        {
            simpanBtn.gameObject.SetActive(false);

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
        image.gameObject.SetActive(true);
        image.sprite = item.itemSprite;
        quantityText.text = quantity.ToString();
        barTimer = item.semaiTime;
        timer = item.semaiTime;
    }

    public void Tanam()
    {
        farmManager.SelectedPlant(this.item.plant);
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
        image.gameObject.SetActive(false);
        image.sprite = null;
        barTimer = 0;
        timer = 0;
    }
}
