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
}
