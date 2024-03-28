using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenihDoneInventory
{
    public event EventHandler OnItemListChanged;

    private List<BenihSO> benihList;

    public BenihDoneInventory()
    {
        benihList = new List<BenihSO>();

      
        Debug.Log(benihList.Count);
    }

    public void AddItem(BenihSO benih)
    {
        benihList.Add(benih);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);   
    }

    public List<BenihSO> GetItemList() 
    {
        return benihList;
    }
   
}
