using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Storage
{
    List<ActiveSlot> actives = new List<ActiveSlot>();
    List<ArmorSlot> armors = new List<ArmorSlot>();
    public Inventory(string _owner,int AmountOfSlots, int AmountOfActives)
    {
        slots.Capacity = AmountOfSlots;
        actives.Capacity = AmountOfActives;
        owner = _owner;
        InitializeSlots(AmountOfSlots);
        InitializeActives(AmountOfActives);
    }
    public Inventory(string _owner,int AmountOfSlots, int AmountOfActives, int AmountOfArmor )
    {
        slots.Capacity = AmountOfSlots;
        actives.Capacity = AmountOfActives;
        armors.Capacity = AmountOfArmor;
        owner = _owner;
        InitializeSlots(AmountOfSlots);
        InitializeActives(AmountOfActives);
    }
    void InitializeActives(int amountOfSlots)
    {
        for(int i = 0; i < amountOfSlots; i++)
        {
            actives.Add(new ActiveSlot());
        }
    }
    public List<ActiveSlot> GetActives()
    {
        return actives;
    }

}
