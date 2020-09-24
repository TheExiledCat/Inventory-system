using System;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class InventorySlot 
{
    public event Action OnChange;
    [SerializeField]
    Item myItem;
    int itemAmount;
    public Item GetItem()
    {
        return myItem;
    }
    public void Refresh()
    {
        OnChange?.Invoke();
    }
    public void SetItem(Item item,int amount)
    {
        myItem = item;
        itemAmount = amount;
        OnChange?.Invoke();
    }
    public int GetItemAmount()
    {
        return itemAmount;
    }
    public void SetItemAmount(int amount)
    {
        itemAmount = amount;
        OnChange?.Invoke();
    }
    public void ChangeAmount(int delta)
    {

        itemAmount += delta;
        OnChange?.Invoke();
    }
}
