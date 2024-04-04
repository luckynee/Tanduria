using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;

public class UI_Inventory : MonoBehaviour
{
    private InventoryGreenHouseSO inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    [SerializeField] private SemaiManager semai;

    private void Awake()
    {
        itemSlotContainer = transform.Find("UI_ItemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("UI_ItemSlotTemplate");
    }

    public void SetInventory(InventoryGreenHouseSO inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float itemSlotCellSize = 120f;
        foreach (ItemGreenHouseSO item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () =>
            {
                if (semai.HasEmptySlot())
                {
                    // Jika ada slot kosong, tambahkan item ke inventaris
                    int removedAmount = inventory.RemoveItem(item);
                    semai.SetItem(item, removedAmount);
                }
                else
                {
                    Debug.Log("Tidak ada slot kosong di SemaiManager!");
                }
            };


            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = item.itemSprite;
            TextMeshProUGUI uiText = itemSlotRectTransform.Find("amountText").GetComponent<TextMeshProUGUI>();
            if(item.amount > 1)
            {
                uiText.SetText(item.amount.ToString());

            } else
            {
                uiText.SetText("");
            }
            x++;
            if(x > 4)
            {
                x = 0;
                y++;
            }
        }
    }
}
