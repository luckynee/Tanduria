using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingBenih : MonoBehaviour
{
    public ItemInstance item; 
    public InventorySO inventory;
    public int benihStock = 100;


    public void MasukanItem()
    {
        if (benihStock > 0)
        {
            inventory.AddItem(item);
            benihStock--;
        }
       
    }

    public void KurangiBenih()
    {
        inventory.RemoveItem(item);
    }

    private void MasukkanBenihKeGreenHouse()
    {

    }
}
