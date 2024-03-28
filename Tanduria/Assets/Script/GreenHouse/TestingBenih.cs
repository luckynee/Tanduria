using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingBenih : MonoBehaviour
{
    public ItemInstance item; 
    public InventorySO inventory;
    
    public void MasukanItem()
    {
        inventory.AddItem(item);
    }
}
