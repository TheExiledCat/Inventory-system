using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Storage 
{
    protected string owner;
    [SerializeField]
    protected List<InventorySlot> slots = new List<InventorySlot>();
    
    public void InitializeSlots(int size)
    {
        for(int i = 0; i < size;i++)
        {
            slots.Add(new InventorySlot());
        }
    }
    public List<InventorySlot> GetSlots()
    {
        return slots;
    }
    public void SetOwner(string o)
    {
        owner = o;
    }
    public string GetOwner()
    {
        return owner;
    }
    public void SetSlots(List<InventorySlot> s)
    {
        slots = s;
    }
   
    public InventorySlot GetSlotByID(int id)
    {
        return slots[id];
    }
    public void Swap(int a,int b,Storage other)
    {
        Item bItem;
        int amount;
        if (other == this)
        {
            bItem = slots[b].GetItem();
            amount = slots[b].GetItemAmount();
            slots[b].SetItem(slots[a].GetItem(),slots[a].GetItemAmount());
            
            Debug.Log("swapping inside inventory");
        }
        else
        {
            bItem = other.GetSlotByID(b).GetItem();
            amount = other.GetSlotByID(b).GetItemAmount();
            other.GetSlotByID(b).SetItem(slots[a].GetItem(),slots[a].GetItemAmount());
            

            
            Debug.Log("swapping outside inventory");
        }
        slots[a].SetItem(bItem, amount);

    }
    public void Fill(Item i)
    {
        foreach(InventorySlot inv in slots)
        {
            if (inv.GetItem())
            {
                break;
            }
            else
            {
                inv.SetItem(i, i.maxStackAmount);
            }
        }
    }
    //public void Sort(int order)
    //{

    //    if(order == 0)
    //    {
    //        slots.Sort(CompareListByName);
    //    }
    //    else
    //    {
    //        slots.Sort(CompareListByName);
    //    }
    //}
    //private static int CompareListByName(InventorySlot i1, InventorySlot i2)
    //{
    //    return i1.GetItem().itemName.CompareTo(i2.GetItem().itemName);
    //}
    public void Fill(Item i,Item j)
    {
        for(int x=0;x<slots.Count/2;x++)
        {
            if (slots[x].GetItem())
            {
                break;
            }
            else
            {
                slots[x].SetItem(i, i.maxStackAmount);
            }
        }
        for (int x = slots.Count/2; x < slots.Count; x++)
        {
            if (slots[x].GetItem())
            {
                break;
            }
            else
            {
                slots[x].SetItem(j, j.maxStackAmount);
            }
        }
    }
}
